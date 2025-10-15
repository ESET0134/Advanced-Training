### Quick Bill from Two Readings

Problem
    
    Write a console app that:
    1. Prompts for meterSerial (string), prevReading (int), currReading (int).
    2. Computes units = currReading - prevReading.
    3. If units ≤ 0, print an error.
    4. Else compute energyCharge = units * 6.5 and a tax = 5% and total = energyCharge + tax.
    5. Print a one-line bill summary.

Guidance

1. Use string, int, double.
2. Use arithmetic operators and an if/else guard.
3. Format to 2 decimals with ToString("F2").

Sample Input

    meterSerial = "AP-000123"  
    prevReading = 12500  
    currReading = 12620   

Expected Output

    Meter AP-000123 | Units: 120 | Energy: ₹780.00 | Tax(5%): ₹39.00 | Total: ₹819.00   `

Stretch

1. Add validation: reject negative readings.
2. If units > 500, print “High usage alert”.

Evaluation

1. Correct types & arithmetic
2. Proper conditional for invalid case
3. Clean, formatted output