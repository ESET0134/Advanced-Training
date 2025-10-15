### Interface for Reading --- IReadable

Goal: Program to interface.

Problem

    Define IReadable:

    public interface IReadable
    {
        int ReadKwh();             // returns delta since last poll
        string SourceId { get; }
    }

Implement:

1. DlmsMeter : IReadable (returns a random 1--10 kWh).
2. ModemGateway : IReadable (returns a random 0--2 kWh representing backfill).

Tasks

1. Put both in List<IReadable> and poll 5 times (loop).
2. Print "SourceId -> deltaKwh" for each poll.

Expected Output (sample)

    AP-0001 -> 7
    GW-21   -> 1
    ...

Stretch

    Add seeded Random so results are deterministic for tests.

Checks

    Both classes satisfy interface; loop uses interface only.