### Polymorphism with Strategy --- IBillingRule

Goal: 

    Replace switch with polymorphic strategy.

Problem

    Define:

    public interface IBillingRule { double Compute(int units); }
    class DomesticRule : IBillingRule { /* 6.0/unit + 50 fixed */ }
    class CommercialRule : IBillingRule { /* 8.5/unit + 150 fixed */ }
    class AgricultureRule : IBillingRule { /* 3.0/unit + 0 fixed */ }
    Create BillingEngine with IBillingRule Rule; and double GenerateBill(int units).

Tasks

1. With units=120, compute bills using each rule instance.
2. Print category + amount.

Expected Output

    DOMESTIC -> ₹770.00
    COMMERCIAL -> ₹1170.00
    AGRICULTURE -> ₹360.00

Stretch

    Add TimeOfDay multiplier (e.g., 1.2× for peak) via optional ctor arg or property and apply in Compute.

Checks

    No switch in engine; pure interface polymorphism.