using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Currency_Converter.Models
{
    public class GivenMoney
    {
        public Double Value { get; set; }
        public Currencies currency { get; set; }
        public Currencies wanted_currency { get; set; }

        public GivenMoney()
        {
            currency = new Currencies();
            wanted_currency = new Currencies();
        }
    }
}
