using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace FinanceAppClient
{
    public class Program
    {

        public ILog Log { get; set; }

        static void ListAllTransactions(Default.Container container)
        {
            foreach (var p in container.Transactions)
            {
                Console.WriteLine(p.ToString());
            }
        }

        static void AddTransaction(Default.Container container, FinanceAppService.Models.Transaction transaction)
        {
            container.AddToTransactions(transaction);
            var serviceResponse = container.SaveChanges();
            foreach (var operationResponse in serviceResponse)
            {
                Console.WriteLine("Response: {0}", operationResponse.StatusCode);
            }
        }

        static void Main(string[] args)
        {

            string serviceUri = "http://localhost:51323/";
            var container = new Default.Container(new Uri(serviceUri));

            var product = new FinanceAppService.Models.Transaction()
            {
                Id = 0
            };

            AddTransaction(container, product);
            ListAllTransactions(container);
        }
    }
}