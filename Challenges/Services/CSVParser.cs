using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace Challenges.Services
{
    public class CSVParser
    {
        public IEnumerable<T> ReadCsv<T>(string filePath, CSVParsingOptions options)
            where T : class, new()
        {
            var config = new CsvConfiguration(options.Culture);
            config.HasHeaderRecord = options.HasHeaders;
            config.Delimiter = options.Delimiter;
            config.ReadingExceptionOccurred = x => options.OnError.Invoke(x.Exception);

            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, config);
            var records = csv.GetRecords<T>();

            return records.ToList();
        }

        public void SaveCsv<T>(IEnumerable<T> records, string filePath, CSVParsingOptions options)
            where T : class, new()
        {
            var config = new CsvConfiguration(options.Culture);
            config.Delimiter = options.Delimiter;
            config.ReadingExceptionOccurred = x => options.OnError.Invoke(x.Exception);

            using var writer = new StreamWriter(filePath);
            using var csv = new CsvWriter(writer, config);
            csv.WriteRecords<T>(records);
        }
    }

    public class CSVParsingOptions
    {
        public CultureInfo Culture { get; set; }
        public string Delimiter { get; set; }
        public Func<Exception, bool> OnError { get; set; }
        public bool HasHeaders { get; set; }

        public CSVParsingOptions()
        {
            Culture = CultureInfo.InvariantCulture;
            Delimiter = ";";
            OnError = x => throw x;
            HasHeaders = false;
        }
    }
}
