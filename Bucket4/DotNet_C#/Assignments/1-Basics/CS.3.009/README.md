### Analyze Tamper & Outage Patterns

Problem

    1. Simulate meter status logs for a week:Each day record:Status = "OK", "OUTAGE", "TAMPER", "LOW_VOLT".
    2. Write a loop:
        Count how many times each event occurs.
        If outage count > 2 OR tamper count > 1 → print “Maintenance required”.
        Else print “Meter healthy”.

Use Concepts

1. foreach
2. Logical OR (||) and AND (&&)
3. Nested conditionals

Sample Data
    
    L  string[] status = { "OK", "OUTAGE", "OK", "TAMPER", "OUTAGE", "OK", "LOW_VOLT" };  

Expected Output

    OK: 3 | OUTAGE: 2 | TAMPER: 1 | LOW_VOLT: 1  Meter healthy  

Stretch

    Add “Suspicious Pattern” if tamper occurs right after an outage.