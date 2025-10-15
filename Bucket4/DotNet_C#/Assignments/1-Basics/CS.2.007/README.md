### Meter Category-based Tariff using switch

Problem

    Given a meterCategory ("DOMESTIC", "COMMERCIAL", "AGRICULTURE"):
    1. Use switch to assign rate:
        DOMESTIC → ₹6.0/unit
        COMMERCIAL → ₹8.5/unit
        AGRICULTURE → ₹3.0/unit
    2. Calculate total bill for given units.

Use Concepts

1. switch
2. Arithmetic + assignment
3. String comparison

Sample Input
  
    meterCategory = "COMMERCIAL"  units = 120  

Expected Output

    Category: COMMERCIAL | Rate: ₹8.5 | Total Bill: ₹1020.00  

Stretch

    Add a default case → “Unknown category. Check configuration.”