using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace BusinessAPI.Domain.Bitcoin
{
    public class BitcoinTickerForCurrencyModel
    {
        [Required]
        public string currency { get; set; }

    }
}
