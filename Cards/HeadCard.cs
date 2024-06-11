using CardProject.Cards.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardProject.Cards
{
    public abstract class HeadCard : CardGenerator
    {
        #region Fields

        // Account number is actually 14 digits long, but the first 4 is always 3520 for our bank.
        private protected const int ACCOUNTNUMBERAMOUNT = 10;
        private const int BANKPREFIX = 3520;

        // Random variable 
        private protected Random _random = new Random();

        // Defining my fields to be used by other classes
        private protected string _cardHolderName;
        private protected int _cardNumberCount;
        private protected int _cardPrefix;
        private protected string? _cardNumber;
        private protected string _accountNumber;

        // Card expire date can be null, therefore there is a ? after the datatype.
        private protected DateTime? _cardExpireDate;
        private protected DateTime _cardCreationTime;

        // Bool to control if the card is still useable.
        private protected bool _isCardLive;

        // List of random names to give our card holders
        private List<string> _names = 
            [
                "Jonas Knudsen",
                "Marcus Lystrup",
                "Nicklas Jensen",
                "Robert Pedersen",
                "Simon Willander",
                "Christina Sørensen",
                "Jens Andersen",
                "Anders Hansen",
                "Mikkel Krøll",
                "Kris Kristensen",
                "David Svarer"
            ];

        #endregion Fields

        #region Properties

        public string CardHolderName
        {
            get { return _cardHolderName; }
            set { _cardHolderName = value; }
        }

        public int CardNumberCount
        {
            get { return _cardNumberCount; }
            set {  _cardNumberCount = value; }
        }

        public string CardNumber
        {
            get { return _cardNumber; } 
            set { _cardNumber = value; }
        }

        public int CardPrefix
        {
            get { return _cardPrefix; }
            set { _cardPrefix = value; }
        }

        public string AccountNumber
        {
            get { return _accountNumber; }
            set { _accountNumber = value; }
        }

        public DateTime? CardExpireDate
        {
            get { return _cardExpireDate; }
            set { _cardExpireDate = value; }
        }

        public DateTime CardCreationTime
        {
            get { return _cardCreationTime; }
            set { _cardCreationTime = value; }
        }

        public bool IsCardLive
        {
            get { return _isCardLive; }
            set { _isCardLive = value; }
        }
        #endregion

        #region Methods

        /// <summary>
        /// This method tests if the card is live
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        private protected bool isExpired(HeadCard card)
        {
            if(card._cardCreationTime == card._cardExpireDate)
            {
                _isCardLive = false;
            }
            else
            {
                _isCardLive = true;
            }
            return _isCardLive;
        }

        /// <summary>
        /// This method returns a random name from our list of random names.
        /// </summary>
        /// <returns></returns>
        private protected string GenerateCardHolder()
        {
            return _names[_random.Next(1, 11)];
        }

        /// <summary>
        /// This method generates a random cardnumber, with a given prefix.
        /// </summary>
        /// <param name="cardNumberCount"></param>
        /// <param name="cardPrefix"></param>
        /// <returns></returns>
        public string GenerateCardNumber(int cardNumberCount, int cardPrefix) 
        {
            // Getting the amount of numbers we have to generate, by getting the length of our current prefix, to make sure that if our prefix is 7, only 1 digit will be removed from the start of cardnumber
            // but if our prefix is multiple digits, x amount of digits will be removed from the start of our cardnumber, and in place our prefix will be added.

            // Creating new list of cardnumbers, and adding our cardprefix
            List<int> cardNumbers = new List<int> { cardPrefix };

            // Generating card numbers and adding them to our list
            for (int i = 0; i < cardNumberCount; i++)
            {
                cardNumbers.Add(_random.Next(0, 9));
            }

            // Converting our list to a string
            string combinedString = string.Join("", cardNumbers);

            // Card number has been generated
            return combinedString;
        }

        /// <summary>
        /// Superficial method, this will only be overriden in the classes its necessary for (if a card can have different prefixes)
        /// </summary>
        /// <returns></returns>
        public virtual int GenerateCardPrefix()
        {
            return _cardPrefix;
        }

        /// <summary>
        /// Generating a account number
        /// </summary>
        /// <returns></returns>
        public string GenerateAccountNumber()
        {
            List<int> accountNumbers = [BANKPREFIX];
            for(int i = 0; i < ACCOUNTNUMBERAMOUNT; i++)
            {
                accountNumbers.Add(_random.Next(0, 9));
            }
            string combinedString = string.Join("", accountNumbers);
            return combinedString;
        }
        #endregion

    }
}
