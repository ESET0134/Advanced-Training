### Class & Object Fundamentals --- Meter

Goal: 
    
    Encapsulate state + behavior.

Problem

    Create a Meter class with:
    1. Fields/props: MeterSerial (string), Location (string), InstalledOn (DateTime), LastReadingKwh (int).
    2. Methods:
        1. AddReading(int deltaKwh): adds to LastReadingKwh if deltaKwh > 0, else ignore.
        2. Summary(): returns "SERIAL Location: X | Reading: Y".

Tasks

    1. Instantiate two meters, set properties via object initializer.
    2. Call AddReading with valid and invalid deltas.
    3. Print Summary() for each.

Expected Output (example)

    AP-0001 Location: Feeder-12 | Reading: 15230
    AP-0002 Location: DTR-9     | Reading:  9800

Stretch

    1. Make fields auto-properties with validation in set.
    2. Add ToString() and just Console.WriteLine(meter).

Checks

    Object creation works; guard against negative deltas; clean formatting.