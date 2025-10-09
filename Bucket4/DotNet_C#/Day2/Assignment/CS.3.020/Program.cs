namespace CS._3._020
{
    public abstract class Event : IComparable<Event>
    {
        public DateTime When { get; }
        public string MeterSerial { get; }

        protected Event(DateTime when, string meterSerial)
        {
            When = when;
            MeterSerial = meterSerial;
        }

        public abstract string Category { get; }
        public abstract int Severity { get; }

        public virtual string Describe()
        {
            return $"{When:yyyy-MM-dd HH:mm} [{Category}] {MeterSerial}";
        }

        public int CompareTo(Event? other)
        {
            if (other == null) return -1;

            int severityCompare = other.Severity.CompareTo(this.Severity);
            if (severityCompare != 0) return severityCompare;

            return other.When.CompareTo(this.When);
        }
    }

    public class OutageEvent : Event
    {
        public override string Category => "OUTAGE";
        public override int Severity => 3;
        public int DurationMinutes { get; }

        public OutageEvent(DateTime when, string meterSerial, int durationMinutes)
            : base(when, meterSerial)
        {
            DurationMinutes = durationMinutes;
        }

        public override string Describe()
        {
            return $"{base.Describe()} | Duration: {DurationMinutes} min | Severity: {Severity}";
        }
    }

    public class TamperEvent : Event
    {
        public override string Category => "TAMPER";
        public override int Severity => 5;
        public string Code { get; }

        public TamperEvent(DateTime when, string meterSerial, string code)
            : base(when, meterSerial)
        {
            Code = code;
        }

        public override string Describe()
        {
            return $"{base.Describe()} | Code: {Code} | Severity: {Severity}";
        }
    }

    public class VoltageEvent : Event
    {
        public override string Category => "VOLTAGE";
        public override int Severity => 2;
        public int Voltage { get; }

        public VoltageEvent(DateTime when, string meterSerial, int voltage)
            : base(when, meterSerial)
        {
            Voltage = voltage;
        }

        public override string Describe()
        {
            return $"{base.Describe()} | V: {Voltage} | Severity: {Severity}";
        }
    }

    // Processor class
    public class EventProcessor
    {
        public static void PrintTopSevere(IEnumerable<Event> events, int topN)
        {
            var topEvents = events.OrderBy(e => e).Take(topN);
            foreach (var ev in topEvents)
            {
                Console.WriteLine(ev.Describe());
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var events = new List<Event>
            {
                new TamperEvent(new DateTime(2025, 10, 6, 9, 20, 0), "AP-0007", "MISMATCH"),
                new OutageEvent(new DateTime(2025, 10, 5, 22, 10, 0), "AP-0003", 95),
                new VoltageEvent(new DateTime(2025, 10, 5, 18, 0, 0), "AP-0001", 184),
                new VoltageEvent(new DateTime(2025, 10, 4, 15, 30, 0), "AP-0002", 190),
                new OutageEvent(new DateTime(2025, 10, 3, 14, 0, 0), "AP-0004", 30),
                new TamperEvent(new DateTime(2025, 10, 2, 12, 0, 0), "AP-0005", "TAMPERED"),
                new VoltageEvent(new DateTime(2025, 10, 1, 11, 0, 0), "AP-0006", 178),
                new OutageEvent(new DateTime(2025, 9, 30, 9, 0, 0), "AP-0008", 45),
            };

            Console.WriteLine("--- Top 3 Most Severe Events ---");
            EventProcessor.PrintTopSevere(events, 3);

            Console.WriteLine("\n--- Stretch Goal: Sorting via IComparable ---");
            events.Sort();
            foreach (var ev in events.Take(3))
            {
                Console.WriteLine(ev.Describe());
            }
        }
    }
}