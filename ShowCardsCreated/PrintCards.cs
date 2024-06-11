using CardProject.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardProject.ShowCardsCreated
{
    public class PrintCards
    {
        public void PrintAllCards(List<HeadCard> cardsToPrint)
        {
            foreach (HeadCard card in cardsToPrint) 
            {
                Console.WriteLine($"The type of card is {card.GetType().Name}");
                Console.WriteLine($"The cardholder is {card.CardHolderName}");
                Console.WriteLine($"The prefix is {card.CardPrefix}");
                Console.WriteLine($"The cardnumber is {card.CardNumber}");
                Console.WriteLine($"The account number is {card.AccountNumber}");
                Console.WriteLine($"The card was Created at {card.CardCreationTime}");
                if(card.CardExpireDate != null)
                {
                    Console.WriteLine($"The card will expire at {card.CardExpireDate}");
                }
                else if(card.CardExpireDate == null)
                {
                    Console.WriteLine($"The card doesnt have an experation date");
                }
                if(card.IsCardLive)
                {
                    Console.WriteLine("The card is active");
                }
                else if(!card.IsCardLive)
                {
                    Console.WriteLine("The card is not active");
                }

                Console.WriteLine("\n\n");
            }
        }
    }
}
