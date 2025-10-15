### Loop-based Daily Consumption Summary

Problem

    Simulate 7-day load readings in an array.
    1. Compute total and average consumption.
    2. Count how many days exceed 6 kWh (peak days).
    3. Count outage days (0 kWh).

Use Concepts

1. for loop
2. if with logical & comparison operators
3. Arithmetic accumulation

Sample Data

    double[] daily = { 5.2, 6.8, 0.0, 7.5, 6.0, 4.8, 0.0 };  

Expected Output

    Total: 30.3 kWh | Avg: 4.33 kWh | Peak Days (>6): 2 | Outages: 2  

Stretch

    Print message:
        Performance Status: Stable / Unstable  
    (where Stable = outageDays ≤ 1 and peakDays ≤ 2)