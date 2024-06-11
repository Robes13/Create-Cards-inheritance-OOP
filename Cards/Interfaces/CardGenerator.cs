using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardProject.Cards.Interfaces
{
    public  interface CardGenerator
    {
        public string GenerateCardNumber(int cardNumberCount, int cardPrefix);
    }
}
