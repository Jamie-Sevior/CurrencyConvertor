using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Currency_Converter.Models
{
    public class ConvertedMoney
    {
        public double Value { get; set; }
        public Currencies currency { get; set; }
        public Currencies NewCurrency { get; set; }
        public double NewValue { get; set; }

        public ConvertedMoney()
        {
        }
        public ConvertedMoney(GivenMoney givenmoney, APIReturn aPIReturn)
        {
            if (aPIReturn.base_code != "error")
            {
                currency = givenmoney.currency;
                Value = givenmoney.Value;
                NewCurrency = givenmoney.wanted_currency;
                double ratio_to_dollar = get_currency_ratio(givenmoney.currency.Type, aPIReturn.conversion_rates);
                double ratio_from_dollar = get_currency_ratio(NewCurrency.Type, aPIReturn.conversion_rates);
                NewValue = (givenmoney.Value / ratio_to_dollar) * ratio_from_dollar;
            }
            else
            {
                this.currency.Type = "error";
            }
        }

        private double get_currency_ratio(string Type, APIReturn.ConversionRates rates)
        {
            double ratio = 0;
            switch (Type)
            {
                case "GBP":
                    return rates.GBP;

                case "USD":
                    return rates.USD;

                case "EUR":
                    return rates.EUR;

                    // case "KWD":
                    //   return rates.KWD;



           }
            return ratio;
        }
    }
}
