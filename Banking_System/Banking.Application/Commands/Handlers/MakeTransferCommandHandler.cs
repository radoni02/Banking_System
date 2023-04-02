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

        public MakeTransferCommandHandler(IUserRepository userRepository, IBankAccountRepository bankAccountRepository)
        {
            _userRepository = userRepository;
            _bankAccountRepository = bankAccountRepository;
        }

        public async Task HandleAsync(MakeTransferCommand command, CancellationToken cancellationToken = new CancellationToken())
        {
            var sender = await _userRepository.GetAsync(command.userId);
            ArgumentNullException.ThrowIfNull(sender);
            var senderAccount = sender.Accounts.FirstOrDefault(x => x.Id == command.accountId);
            var properSenderBalance = senderAccount.AccountBalances.FirstOrDefault(x => x.Currency == command.transferdata.Currency);
            if(properSenderBalance is null)
            {
                throw new Exception();
            }
            var status = senderAccount.CheckIfSenderHaveEnoughMoney(command.transferdata.Amount,
                                                                senderAccount.Card.Type,
                                                                TransferStatus.Created,
                                                                properSenderBalance);
            var bankTransfer = BankTransfer.Create(command.transferdata.Title,
                                                    command.transferdata.Amount,
                                                    command.transferdata.ReceiverAdressAndData,
                                                    status,
                                                    command.transferdata.IsConstant,
                                                    command.transferdata.AccountNumber,
                                                    Currency.PLN);
            senderAccount.UpdateMoneyBalanceSender(properSenderBalance);
            var reciverAccount = await _bankAccountRepository.GetByAccountNumberAsync(command.transferdata.AccountNumber);
            if(reciverAccount is null)
            {
                status = TransferStatus.Failed;
                throw new Exception();
            }
            status = reciverAccount.CurrencyChecking(command.transferdata.Currency,status);
            if (status is not TransferStatus.Successful)
            {
                //call some external service to change currency and updatebalanceReciver, for now it will be exception //currency conversion
                throw new Exception();
            }
            reciverAccount.AddTransfer(bankTransfer);
            var senderBankTransfer = bankTransfer.GetTransferForSender(bankTransfer);
            senderAccount.AddTransfer(senderBankTransfer);

            await _bankAccountRepository.UpdateAsync(senderAccount);
            await _bankAccountRepository.UpdateAsync(reciverAccount);
        }
    }
}
