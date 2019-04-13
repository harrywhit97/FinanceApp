using System;

namespace FinanceAppClient
{
    class Program
    {
        static void ListAllProducts(Default.Container container)
        {
            foreach (var t in container.Transactions)
            {
                Console.WriteLine("{0} {1} ", t.Id, t.Amount);
            }
        }

        static void AddProduct(Default.Container container, FinanceAppService.Models.Transaction product)
        {
            var serviceResponse = container.SaveChanges();
            foreach (var operationResponse in serviceResponse)
            {
                Console.WriteLine("Response: {0}", operationResponse.StatusCode);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Starting...");
            // TODO: Replace with your local URI.
            string serviceUri = "http://localhost:51323";
            var container = new Default.Container(new Uri(serviceUri));

            var transaction = new FinanceAppService.Models.Transaction()
            {
                Id = 0,
                Amount = 2.0
            };

            AddProduct(container, transaction);
            ListAllProducts(container);

            Console.ReadKey();
        }
    }
}
