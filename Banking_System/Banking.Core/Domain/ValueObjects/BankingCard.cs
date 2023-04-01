using Banking.Core.Domain.Consts;
using Banking.Core.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Banking.Core.Domain.ValueObjects
{
    public sealed class BankingCard
    {
        private const int ValidLengthofCardNumber = 16;
        private const int ValidLengthOfCVV = 3;
        private const int MaxLengthOfHolderName = 50;

        public string CardNumber { get; }
        public string CardHolderName { get; }
        public BankCard Type { get;private set; }

        public DateTime CardValidityDate { get; }

        public string CVV { get; }
        public static BankingCard CreateDebitCard(string cardNumber, string cardHolderName, BankCard type, DateTime cardValidityDate, string cVV)
        {
            type = BankCard.DebitCard;
            var card =new BankingCard(cardNumber, cardHolderName, type, cardValidityDate, cVV);
            if(card is null)
            {
                throw new Exception();
            }
            return card;
        }
        public static BankingCard CreateCreditCard(string cardNumber, string cardHolderName, BankCard type, DateTime cardValidityDate, string cVV)
        {
            type = BankCard.CreditCard;
            var card =new BankingCard(cardNumber, cardHolderName, type, cardValidityDate, cVV);
            if (card is null)
            {
                throw new Exception();
            }
            return card;
        }

        private BankingCard(string cardNumber, string cardHolderName, BankCard type, DateTime cardValidityDate, string cVV)
        {
            if (string.IsNullOrWhiteSpace(CVV) || string.IsNullOrWhiteSpace(CardNumber) || string.IsNullOrWhiteSpace(CardHolderName))
            {
                throw new Exception();
            }
            if (cardNumber.Length != ValidLengthofCardNumber)
            {
                throw new Exception();
            }
            if (cardHolderName.Length > MaxLengthOfHolderName)
            {
                throw new Exception();
            }
            if (cVV.Length != ValidLengthOfCVV)
            {
                throw new Exception();
            }
            if (!Regex.Match(cVV, @"^\d+$").Success)
            {
                throw new InvalidCharactersException(cVV);
            }
            if (!Regex.Match(cardNumber, @"^\d+$").Success)
            {
                throw new InvalidCharactersException(cardNumber);
            }
            CardNumber = cardNumber;
            CardHolderName = cardHolderName;
            Type = type;
            CardValidityDate = cardValidityDate;
            CVV = cVV;

        }
    }
}
