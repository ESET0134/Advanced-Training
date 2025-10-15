### Inheritance Basics --- Device → Meter / Gateway

Goal: 
    
    Establish base class reuse.
Problem

    Create a Tariff class with:
    1. Base class Device:
        1. Props: Id (string), InstalledOn (DateTime).
        2. Method: Virtual Describe() → "Device Id: ... InstalledOn: ..."
    2. Derived:
        1. Meter adds PhaseCount (int) and overrides Describe() to include it.
        2. Gateway adds IpAddress (string) and overrides Describe().

Tasks

    1. Create Device[] with 1 meter + 1 gateway (polymorphic array).
    2. Loop and Console.WriteLine(d.Describe()).

Expected Output (example)

    Meter Id: AP-0001 | Installed: 2024-07-01 | Phases: 3
    Gateway Id: GW-11 | Installed: 2025-01-10 | IP: 10.0.5.21

Stretch

    Mark Device.Describe() virtual and children override; also add protected ctor in base.

Checks

    Correct override dispatch via base reference.