using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardProject.Cards.CardTypes
{
    internal class Debitcard : HeadCard
    {
        #region Fields
        private const int PREFIX = 2400;

        // No expire date on a debitcard
        #endregion
        public Debitcard()
        {
            _cardHolderName = GenerateCardHolder();
            _cardNumberCount = 14 - PREFIX.ToString().Length;
            _cardPrefix = PREFIX;
            _cardNumber = GenerateCardNumber(_cardNumberCount, PREFIX);
            _accountNumber = GenerateAccountNumber();

            _cardExpireDate = null;
            // Getting current time
            DateTime cardCreated = DateTime.Now;
            // Setting the card creation time
            _cardCreationTime = cardCreated;
            _isCardLive = true;
        }
    }
}
