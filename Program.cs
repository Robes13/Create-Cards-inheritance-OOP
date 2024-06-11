using CardProject.Cards;
using CardProject.Cards.CardTypes;
using CardProject.ShowCardsCreated;

namespace CardProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintCards printCards = new PrintCards();

            VISA visa1= new VISA();
            VISA visa2 = new VISA();

            Debitcard debitcard1 = new Debitcard();
            Debitcard debitcard2 = new Debitcard();

            Maestro maestro1 = new Maestro();
            Maestro maestro2 = new Maestro();

            Mastercard mastercard1 = new Mastercard();
            Mastercard mastercard2 = new Mastercard();

            VISA_Electron visa_Electron1 = new VISA_Electron();
            VISA_Electron visa_Electron2 = new VISA_Electron();

            List<HeadCard> headCards = [debitcard1, debitcard2, maestro1, maestro2, mastercard1, mastercard2, visa1, visa2, visa_Electron1, visa_Electron2];

            printCards.PrintAllCards(headCards);

            Console.ReadKey();
        }
    }
}
