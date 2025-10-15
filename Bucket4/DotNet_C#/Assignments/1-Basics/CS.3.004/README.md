### Multi-Meter Weekly Health Report

Problem

    For 3 meters, each with 7 daily kWh entries:
    1. For each meter:
        Total & average
        PeakAlert if any day > 8 kWh
        SustainedOutage if there are two consecutive zero-days
    2. Across all meters, find the single highest day usage (value + which meter + day)

Guidance

1. Use int[][] meters as a jagged array.
2. Outer loop over meters, inner over days.
3. Use flags for alerts; track per-meter max and global max (with meter/day indexes).

Starter Data

    int[][] meters = new int[][]  {    
        new[] { 4, 5, 0, 0, 6, 7, 3 }, // A    
        new[] { 2, 2, 2, 2, 2, 2, 2 }, // B    
        new[] { 9, 1, 1, 1, 1, 1, 1 }  // C  
    };  
    string[] ids = { "A-1001", "B-2001", "C-3001" };  

Expected Per-Meter Stats

    A-1001: Total 25, Avg 3.57, PeakAlert False, SustainedOutage True (days 3–4)
    B-2001: Total 14, Avg 2.00, PeakAlert False, SustainedOutage False
    C-3001: Total 15, Avg 2.14, PeakAlert True (day 1), SustainedOutage False

Expected Global

1. Highest day = 9 kWh on C-3001 Day 1
2. Example print (one line per meter + summary):

    A-1001 | Total:25 Avg:3.57 | Peak:No | SustainedOutage:Yes  B-2001 | Total:14 Avg:2.00 | Peak:No |  SustainedOutage:No  C-3001 | Total:15 Avg:2.14 | Peak:Yes | SustainedOutage:No  Highest Day: 9 kWh | Meter:   C-3001 | Day: 1  

Stretch

    Also flag Underutilization if weekly average < 2.0 kWh.
Evaluation

1. Nested loops & flags correct
2. Accurate detection of consecutive zeros
3. Clear global max tracking