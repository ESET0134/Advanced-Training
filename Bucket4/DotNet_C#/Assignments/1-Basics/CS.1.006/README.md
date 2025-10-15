### Compute Net Consumption and Alerts

Problem
    
    Write a console app that:
    1. Reads previous and current readings (in kWh).
    2. Calculates the difference (consumption).
    3. Checks:
        If consumption < 0 → Invalid.
        If consumption == 0 → Possible outage.
        If consumption > 500 → High consumption alert.

Use Concepts

1. Arithmetic operators (+, -)
2. Comparison operators (<, ==, >)
3. Logical operators (&&, ||)
4. if statements

Sample Input

    Previous Reading: 15000  Current Reading: 15620  

Expected Output

    Net Consumption: 620 kWh  High Consumption Alert!  

Stretch

    Add logical condition: if consumption > 100 and < 500 → print “Normal usage”.