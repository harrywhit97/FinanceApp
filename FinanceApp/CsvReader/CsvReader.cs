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
                    DateTimeOffset.TryParse(values[0], out DateTimeOffset date);
                    var transaction = new Transaction()
                    {
                        Date = GetDate(values),
                        Amount = GetAmount(values),
                        Class = GetClass(values),
                        Description = GetDescription(values),
                        Location = GetLocation(values)
                    };
                    transactions.Add(transaction);
                }
            }
            return transactions;
        }

        private DateTimeOffset GetDate(string[] values)
        {
            DateTimeOffset.TryParse(values[0], out var date);
            return date;
        }

        private string GetDescription(string[] values)
        {
            return values[1] = values[1].Substring(2); ;
        }

        private string GetLocation(string[] values)
        {
            return values[2].Substring(0, values[2].Length - 2); 
        }

        private string GetClass(string[] values)
        {
            return values[6];
        }

        private double GetAmount(string[] values)
        {
            double.TryParse(values[8], out double amount);
            return amount;
        }
    }
}
