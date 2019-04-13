using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAppClient
{
    class Program
    {
        static void ListAllProducts(Default.Container container)
        {
            foreach (var p in container.Transactions)
            {
                Console.WriteLine("{0} {1}", p.Id, p.Amount);
            }
        }

        static void AddProduct(Default.Container container, FinanceAppService.Models.Transaction transaction)
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
            // TODO: Replace with your local URI.
            string serviceUri = "http://localhost:51323/";
            var container = new Default.Container(new Uri(serviceUri));

            var product = new FinanceAppService.Models.Transaction()
            {
                Amount = 3.0
            };

            AddProduct(container, product);
            ListAllProducts(container);
        }
    }
}