### Multi-meter Outage Duration Analyzer

Problem

    You are given the outage hours for each meter over the week.

    Meter	Hours[]
    MTR001	[1, 0, 0, 5, 2, 0, 0]
    MTR002	[0, 0, 0, 0, 0, 0, 0]
    MTR003	[0, 4, 3, 0, 0, 0, 0]

Tasks:

    1. For each meter:
        Sum total outage hours.
        If total > 8 → “Escalate to field team”.
        If total == 0 → “Stable”.
        Else → “Monitor”.
    2. Use nested for loops & if conditions.
    3. Print summary table.

Use Concepts

1. Nested for loops
2. Logical & comparison operators
3. Conditional classification

Expected Output
   
    MTR001 | Outage Hours: 8 | Action: Monitor  
    MTR002 | Outage Hours: 0 | Action: Stable  
    MTR003 | Outage Hours: 7 | Action: Monitor   

Stretch

    Use while loop variant to verify no negative entries exist (if found, print “Invalid Data”).