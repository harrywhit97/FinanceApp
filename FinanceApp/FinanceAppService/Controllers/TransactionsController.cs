using FinanceAppService.Models;
using Microsoft.AspNet.OData;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace FinanceAppService.Controllers
{
    public class TransactionsController : ODataController
    {
        TransactionsContext db = new TransactionsContext();
        private bool ProductExists(int key)
        {
            return db.Transactions.Any(p => p.Id == key);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        [EnableQuery]
        public IQueryable<Transaction> Get()
        {
            return db.Transactions;
        }
        [EnableQuery]
        public SingleResult<Transaction> Get([FromODataUri] int key)
        {
            IQueryable<Transaction> result = db.Transactions.Where(p => p.Id == key);
            return SingleResult.Create(result);
        }

        public async Task<IHttpActionResult> Post(Transaction transaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Transactions.Add(transaction);
            await db.SaveChangesAsync();
            return Created(transaction);
        }

        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Transaction> transaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await db.Transactions.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            transaction.Patch(entity);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(entity);
        }
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Transaction update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (key != update.Id)
            {
                return BadRequest();
            }
            db.Entry(update).State = EntityState.Modified;
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(update);
        }
    }
}


