### Constructors & Overloads --- Tariff

Goal: 
    
    Define overloaded constructors + chaining.

Problem

    Create a Tariff class with:
    1. Props: Name (string), RatePerKwh (double), FixedCharge (double).
    2. Ctors:
        1. Tariff(string name) → defaults: rate=6.0, fixed=50.
        2. Tariff(string name, double rate) → defaults fixed=50.
        3. Tariff(string name, double rate, double fixedCharge).
    3. ComputeBill(int units) → units * rate + fixed.

Tasks

    1. Create three tariffs using different constructors.
    2. For units=120, print computed bill for each.

Expected Output (example)

    DOMESTIC: ₹770.00
    COMMERCIAL: ₹1170.00
    AGRI: ₹410.00

Stretch

    Add Validate() that throws if rate <= 0 or fixed < 0. Call in constructors.

Checks

    Proper ctor chaining, defaults applied correctly.