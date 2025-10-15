namespace CS._3._018
{
    public interface IDataIngestor
    {
        string Name { get; }
        IEnumerable<(DateTime ts, int kwh)> ReadBatch(int count);
    }
    public class DlmsIngestor : IDataIngestor
    {
        private readonly Random _random = new Random();
        private DateTime _currentTime = DateTime.Now.Date.AddHours(10);

        public string Name => "DLMS Ingestor";

        public IEnumerable<(DateTime ts, int kwh)> ReadBatch(int count)
        {
            var results = new List<(DateTime, int)>();

            for (int i = 0; i < count; i++)
            {
                var kwh = _random.Next(1, 6);
                results.Add((_currentTime, kwh));
                _currentTime = _currentTime.AddHours(1);
            }

            return results;
        }
    }
    public class CsvIngestor : IDataIngestor
    {
        private readonly string[] _csvLines;
        private int _currentIndex = 0;

        public string Name => "CSV Ingestor";

        public CsvIngestor(string[] csvLines)
        {
            _csvLines = csvLines;
        }

        public IEnumerable<(DateTime ts, int kwh)> ReadBatch(int count)
        {
            var results = new List<(DateTime, int)>();

            for (int i = 0; i < count && _currentIndex < _csvLines.Length; i++)
            {
                var line = _csvLines[_currentIndex++];
                var parts = line.Split(',');

                if (parts.Length == 2 &&
                    DateTime.TryParse(parts[0], out var timestamp) &&
                    int.TryParse(parts[1], out var kwh))
                {
                    results.Add((timestamp, kwh));
                }
            }

            return results;
        }
    }
    public class RandomOutageDecorator : IDataIngestor
    {
        private readonly IDataIngestor _wrappedIngestor;
        private readonly Random _random;
        private readonly double _outageProbability;

        public string Name => $"{_wrappedIngestor.Name} + Outages";

        public RandomOutageDecorator(IDataIngestor ingestor, double outageProbability = 0.2)
        {
            _wrappedIngestor = ingestor;
            _random = new Random();
            _outageProbability = outageProbability;
        }

        public IEnumerable<(DateTime ts, int kwh)> ReadBatch(int count)
        {
            var results = _wrappedIngestor.ReadBatch(count);

            return results.Select(result =>
            {
                if (_random.NextDouble() < _outageProbability)
                {
                    return (result.ts, 0);
                }
                return result;
            });
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== DLMS Ingestor with Random Outages ===");

            var dlmsIngestor = new DlmsIngestor();
            var outageDecorator = new RandomOutageDecorator(dlmsIngestor, 0.3);

            var batch = outageDecorator.ReadBatch(10);

            foreach (var record in batch)
            {
                Console.WriteLine($"{record.ts:yyyy-MM-dd HH:mm} -> {record.kwh}");
            }

            Console.WriteLine("\n=== CSV Ingestor Example ===");

            string[] csvData = {
                "2025-10-06 10:00:00,3",
                "2025-10-06 11:00:00,5",
                "2025-10-06 12:00:00,2",
                "2025-10-06 13:00:00,4",
                "2025-10-06 14:00:00,1"
            };

            var csvIngestor = new CsvIngestor(csvData);
            var csvBatch = csvIngestor.ReadBatch(5);

            foreach (var record in csvBatch)
            {
                Console.WriteLine($"{record.ts:yyyy-MM-dd HH:mm} -> {record.kwh}");
            }
        }
    }
}