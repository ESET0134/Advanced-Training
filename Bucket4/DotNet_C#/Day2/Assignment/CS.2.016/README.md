### Constructors, Encapsulation & Computed Props --- LoadProfileDay

Goal: 
    
    Immutable object + computed members.

Problem

    Create:

    class LoadProfileDay
    {
        public DateTime Date { get; }
        public int[] HourlyKwh { get; } // length 24
        public LoadProfileDay(DateTime date, int[] hourly)
        {
        // clone array; validate length == 24; values >= 0
        }
        public int Total => /* sum */;
        public int PeakHour => /* 0..23 of max */;
    }

Tasks

1. Build a valid HourlyKwh array; instantiate a day.
2. Print Date, Total, PeakHour.

Expected Output

    2025-10-01 | Total: 82 kWh | PeakHour: 19

Stretch

    Add int OutageHours => count of zeros.

Checks

    Defensive copy, validation in ctor, read-only API.