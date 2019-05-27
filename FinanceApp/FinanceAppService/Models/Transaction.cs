using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinanceAppService.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
        public string Class { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Location{ get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Date: {Date}, Description: {Description}, Location: {Location},Amount: {Amount}, Class: {Class}";
        }
    }
}