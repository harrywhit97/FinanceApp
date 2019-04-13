using System.Data.Entity;


namespace FinanceAppService.Models
{
    public class TransactionsContext : DbContext
    {
        public TransactionsContext()
                : base("name=TransactionsContext")
        {
        }
        public DbSet<Transaction> Transactions { get; set; }
    }
}