using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardProject.Cards.CardTypes
{
    internal class Maestro : HeadCard
    {
        #region Fields
        private List<int> PREFIXES = [5018, 5020, 5038, 5893, 6304, 6759, 6761, 6762, 6763];

        // This is the max amount of time a maestro card is allowed to be active for.
        private readonly TimeSpan EXPIRE_TIME = TimeSpan.FromDays((5 * 365) + 30 * 8);
        #endregion
        public Maestro()
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
