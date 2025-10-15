### Parse Load Profile Lines (No Files)

Problem

    You’re given 7 CSV-like lines: yyyy-MM-dd,kWh,status where status is OK / OUTAGE / TAMPER.Compute:
    1. Sum of kWh where status == OK
    2. Count of OUTAGE days
    3. Count of TAMPER days
    4. Average kWh across only OK days

Guidance

1. Use string[] lines.
2. For each line: Split(','), double.Parse, if/else if.
3. Keep okCount to compute average.

Starter Data

    string[] lines = {    "2025-09-01,4.2,OK",    "2025-09-02,5.0,OK",    "2025-09-03,0.0,OUTAGE",    "2025-09-04,3.8,OK",    "2025-09-05,6.1,OK",    "2025-09-06,2.5,TAMPER",    "2025-09-07,5.4,OK"  };

Expected Output (deterministic)
    
    OK sum = 24.5 kWh
    OUTAGE days = 1
    TAMPER days = 1
    OK average = 4.90 kWh

Example print:

    OK: 24.50 kWh (avg 4.90) | OUTAGE: 1 | TAMPER: 1  

Stretch

    Track the busiest OK day (date string) and its kWh.

Evaluation

1. Safe parsing and indexing
2. Correct status-based branching
3. Precise totals/averages