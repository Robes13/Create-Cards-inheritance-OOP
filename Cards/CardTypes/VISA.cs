using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardProject.Cards.CardTypes
{
    internal class VISA : HeadCard
    {
        #region Fields
        private const int PREFIX = 4;

        // This is the max amount of time a visa card is allowed to be active for.
        private readonly TimeSpan EXPIRE_TIME = TimeSpan.FromDays(5 * 365);
        #endregion
        public VISA()
        {
            _cardHolderName = GenerateCardHolder();
            _cardNumberCount = 14 - PREFIX.ToString().Length;
            _cardPrefix = PREFIX;
            _cardNumber = GenerateCardNumber(_cardNumberCount, PREFIX);
            _accountNumber = GenerateAccountNumber();
            
            // Getting current time
            DateTime cardCreated = DateTime.Now;

            // Setting the card creation time
            _cardCreationTime = cardCreated;

            // Setting the expire date for the card
            _cardExpireDate = cardCreated.Add(EXPIRE_TIME);

            // Double checking if the card doesnt go over the expiredate when created
            if(cardCreated != DateTime.Now)
            {
                _isCardLive = true;
            }
            else
            {
                _isCardLive = false;
            }
        }
    }
}
