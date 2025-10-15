### Polymorphic Billing with Add-on Interfaces --- IRebate

Goal: 

    Demonstrate multiple interfaces + dynamic composition.

Problem
    
    Use IBillingRule from CS.2.015 and add:

    public interface IRebate
    {
        string Code { get; }
        double Apply(double currentTotal, int outageDays);
    }

Implement rebates:

1. NoOutageRebate → if outageDays==0 then -2%.

2. HighUsageRebate → if units>500 then -3%.

Create BillingContext:

    class BillingContext
    {
        public IBillingRule Rule { get; }
        public List<IRebate> Rebates { get; } = new();
        public BillingContext(IBillingRule rule) => Rule = rule;
        public double Finalize(int units, int outageDays)
        {
            double total = Rule.Compute(units);
            foreach (var r in Rebates) total += r.Apply(total, outageDays);
            return total;
        }
    }

Tasks

1. Rule = Commercial, units=620, outageDays=0. Apply both rebates.

2. Print subtotal and final total.

Expected Output (illustrative)

    Subtotal: ₹  8.5*620 + 150 = ₹  5,  420 + 150 = ₹  5,  570.00
    Rebates: NO_OUTAGE -2% | HIGH_USAGE -3%
    Final: ₹ 5402.10

Stretch

    Add IRebate that adds a penalty when tamperDays>0.

Checks

    Multiple interfaces at play; order of application consistent.