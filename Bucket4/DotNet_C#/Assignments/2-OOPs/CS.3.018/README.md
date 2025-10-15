### Interface Segregation + Multiple Implementations --- IDataIngestor

Goal: 
    
    Hide source specifics behind an interface; compose behaviors.

Problem
    
    Define:

    public interface IDataIngestor
    {
        string Name { get; }
        IEnumerable<(DateTime ts, int kwh)> ReadBatch(int count);
    }

Implement:

1. DlmsIngestor → emits count hourly tuples (ts, kwh=1..5).

2. CsvIngestor → emits from an in-memory string array of CSV lines.

3. RandomOutageDecorator : IDataIngestor → wraps any ingestor and randomly sets some kwh=0.

Tasks

1. Wrap new DlmsIngestor() with RandomOutageDecorator.

2. Call ReadBatch(10) and print 10 lines ts -> kwh.

Expected Output

    [Dlms+Outage] 2025-10-06 10:00 -> 3 ...

Stretch

    Add IRateLimiter interface and a decorator that sleeps or skips every Nth record (simulate HES limits).

Checks

    Interface composition, decorator pattern, clean separation of concerns.