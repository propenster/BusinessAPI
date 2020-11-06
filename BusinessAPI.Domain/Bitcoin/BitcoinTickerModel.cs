using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessAPI.Domain.Bitcoin
{
    public class BitcoinTickerModel
    {
        public string currency { get; set; }
        public string fifteen { get; set; }
        public string last { get; set; }
        public string buy { get; set; }
        public string sell { get; set; }
        public string symbol { get; set; }
    }
}
