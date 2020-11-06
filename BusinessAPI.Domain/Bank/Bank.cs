using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace BusinessAPI.Domain.Bank
{
    public class Bank
    {
        public int Id { get; set; }
        public string BankName { get; set; }
        public string BankCBNCode { get; set; }
        public string BankShortCode { get; set; }
    }
}
