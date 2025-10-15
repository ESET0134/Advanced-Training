### Abstract Base + Overrides --- AlarmRule

Goal: 
    
    Use abstract classes for shared template logic.

Problem
    
    Create:

    abstract class AlarmRule
    {
        public string Name { get; }
        protected AlarmRule(string name) => Name = name;
        public abstract bool IsTriggered(LoadProfileDay day);
        public virtual string Message(LoadProfileDay day)
            => $"{Name} triggered on {day.Date:yyyy-MM-dd}";
    }

    class PeakOveruseRule : AlarmRule
    {   // trigger if day.Total > threshold
        private readonly int _threshold;
        public PeakOveruseRule(int threshold) : base("PeakOveruse") => _threshold = threshold;
        public override bool IsTriggered(LoadProfileDay day) => day.Total > _threshold;
    }

    class SustainedOutageRule : AlarmRule
    {   // trigger if consecutive zero hours >= N
        private readonly int _minConsecutive;
        public SustainedOutageRule(int min) : base("SustainedOutage") => _minConsecutive = min;
        public override bool IsTriggered(LoadProfileDay day) { /* scan */ }
    }

Tasks

1. Build a LoadProfileDay with some zeros & highs.
2. Evaluate rules and print triggered messages.

Expected Output

    PeakOveruse triggered on 2025-10-01

(or both, depending on data)

Stretch

    Add virtual Message override in SustainedOutageRule to include start hour.

Checks

    Correct abstract/override usage; O(n) scan for consecutive zeros.