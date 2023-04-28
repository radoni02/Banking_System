using Banking.Application.Exceptions;
using Banking.Application.Services;
using Banking.Core.Domain.Consts;
using Banking.Core.Domain.Repositories;
using Banking.Core.Domain.ValueObjects;
using Convey.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Application.Commands.Handlers
{
    public class MakeTransferCommandHandler : ICommandHandler<MakeTransferCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly ICurrencyChanger _currencyChanger;

        public MakeTransferCommandHandler(IUserRepository userRepository,
            IBankAccountRepository bankAccountRepository,
            ICurrencyChanger currencyChanger)
        {
            _userRepository = userRepository;
            _bankAccountRepository = bankAccountRepository;
            _currencyChanger = currencyChanger;
        }

        public async Task HandleAsync(MakeTransferCommand command, CancellationToken cancellationToken = new CancellationToken())
        {
            var sender = await _userRepository.GetAsync(command.UserId);
            if(sender is null)
            {
                throw new UserNotFoundException(command.UserId);
            }
            var senderAccount = sender.Accounts.FirstOrDefault(x => x.Id == command.AccountId);
            if(senderAccount is null)
            {
                throw new AccountNotFoundException();
            }
            var properSenderBalance = senderAccount.AccountBalances.FirstOrDefault(x => x.Currency == command.Transferdata.Currency);
            if(properSenderBalance is null)
            {
                throw new SenderBalanceNotFoundException(command.Transferdata.Currency);
            }
            var status = senderAccount.CheckIfSenderHaveEnoughMoney(command.Transferdata.Amount,
                                                                senderAccount.Card.Type,
                                                                TransferStatus.Created,
                                                                properSenderBalance);
            var reciverAccount = await _bankAccountRepository.GetByAccountNumberAsync(command.Transferdata.AccountNumber);
            if (reciverAccount is null)
            {
                status = TransferStatus.Failed;
                throw new ReciverAccountNotFoundException();
            }
            var bankTransfer = BankTransfer.Create(command.Transferdata.Title,
                                                    command.Transferdata.Amount,
                                                    command.Transferdata.ReceiverAdressAndData,
                                                    status,
                                                    command.Transferdata.IsConstant,
                                                    command.Transferdata.AccountNumber,
                                                    Currency.PLN,
                                                    senderAccount.Id,
                                                    reciverAccount.Id);
            senderAccount.UpdateMoneyBalanceSender(properSenderBalance,command.Transferdata.Amount);
            
            status = reciverAccount.CurrencyChecking(command.Transferdata.Currency,status,command.Transferdata.Amount);
            if (status is not TransferStatus.Successful)
            {
                //we assume that default currency is PLN
                var amountInPln = _currencyChanger.ChangeCurrency(properSenderBalance.Currency,command.Transferdata.Amount);
                var properReciverBalance = reciverAccount.AccountBalances.FirstOrDefault(x => x.Currency == Currency.PLN);
                if(properReciverBalance is null)
                {
                    throw new ReciverBalanceNotFoundException();
                }
                reciverAccount.UpdateMoneyBalanceReciver(properReciverBalance,amountInPln);
                status = TransferStatus.Successful;
            }
            reciverAccount.AddTransfer(bankTransfer);
            var senderBankTransfer = bankTransfer.GetTransferForSender(bankTransfer);
            senderAccount.AddTransfer(senderBankTransfer);

            await _bankAccountRepository.UpdateAsync(senderAccount);
            await _bankAccountRepository.UpdateAsync(reciverAccount);
        }
    }
}
