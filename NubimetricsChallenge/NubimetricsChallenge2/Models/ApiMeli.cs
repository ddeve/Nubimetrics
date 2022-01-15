using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NubimetricsChallenge2.Models
{
    public class Currency
    {
        public string id { get; set; }
        public string symbol { get; set; }
        public string description { get; set; }
        public int decimal_places { get; set; }
    }

    public class CurrencyChallenge
    {
        public CurrencyChallenge(Currency currency, CurrencyConvertion currencyConvertion)
        {
            this.id = currency.id;
            this.symbol = currency.symbol;
            this.description = currency.description;
            this.decimal_places = currency.decimal_places;
            this.todolar = currencyConvertion;

        }
        public string id { get; set; }
        public string symbol { get; set; }
        public string description { get; set; }
        public int decimal_places { get; set; }
        public CurrencyConvertion todolar { get; set; }
    }


    public class CurrencyConvertion
    {
        public string currency_base { get; set; }
        public string currency_quote { get; set; }
        public float ratio { get; set; }
        public float rate { get; set; }
        public float inv_rate { get; set; }
        public DateTime creation_date { get; set; }
        public DateTime valid_until { get; set; }
    }

}
