using FinanceAppService.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvReader
{
    public class CsvReader
    {
        public string SourceFolder { get; set; }
        public string DoneFolder { get; set; }

        public CsvReader(string sourceFolder, string doneFolder)
        {
            SourceFolder = sourceFolder;
            DoneFolder = doneFolder;
        }

        public IEnumerable<string> FindFiles()
        {
            var filesInFolder = Directory.GetFiles(SourceFolder);
            return filesInFolder.Where(x => Path.GetExtension(x).Equals(".csv"));
        }

        public IList<Transaction> ReadFile(string file)
        {
            var transactions = new List<Transaction>();
            using (var reader = new StreamReader(file))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');


                }
            }
            return transactions;
        }
    }

        public Transaction GenerateTransaction(string description, string amount, string date, string transactionClass)
        {
            throw new NotImplementedException();
        }

    }
}
