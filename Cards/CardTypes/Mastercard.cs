using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardProject.Cards.CardTypes
{
    internal class Mastercard : HeadCard
    {
        #region Fields
        private List<int> PREFIXES = [51, 52, 53, 54, 55];

        // This is the max amount of time a master card is allowed to be active for.
        private readonly TimeSpan EXPIRE_TIME = TimeSpan.FromDays(5 * 365);
        #endregion
        public Mastercard() 
        {
            _cardHolderName = GenerateCardHolder();
            _cardPrefix = GenerateCardPrefix();
            _cardNumberCount = 14 - _cardPrefix.ToString().Length;
            _cardNumber = GenerateCardNumber(_cardNumberCount, _cardPrefix);
            _accountNumber = GenerateAccountNumber();

            // Getting current time
            DateTime cardCreated = DateTime.Now;

            // Setting the card creation time
            _cardCreationTime = cardCreated;

            // Setting the expire date for the card
            _cardExpireDate = cardCreated.Add(EXPIRE_TIME);

            // Double checking if the card doesnt go over the expiredate when created
            if (cardCreated != DateTime.Now)
            {
                _isCardLive = true;
            }
            else
            {
                _isCardLive = false;
            }
        }

        #region Methods

        public override int GenerateCardPrefix()
        {
            int cardPrefix = PREFIXES[_random.Next(0, PREFIXES.Count)];
            return cardPrefix;
        }

        #endregion
    }
}
