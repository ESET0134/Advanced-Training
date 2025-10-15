### Monthly Slab Billing with Category & Outage Check

Problem

    Simulate a 30-day month for one meter:
    1. You’re given a 10-day pattern of daily units; repeat it 3× to make 30 days.
    2. Compute:
        monthlyUnits (sum)
        outageDays (entries equal to 0)
    3. Compute energy charge using slabs:
        First 100 units @ ₹4.0
        Next 200 units @ ₹6.0
        Remaining @ ₹8.5
    4. Add fixed charge by category (use a variable):
        DOMESTIC → ₹50
        COMMERCIAL → ₹150
    5. If outageDays == 0, apply 2% rebate on (energy + fixed); otherwise no rebate.
    6. Print a tidy invoice line with the breakdown.

Guidance

1. Build int[] pattern then create int[] month = new int[30] with loops.
2. Use a switch on category string.
3. Compute slabs with arithmetic + if/else if.
4. Keep all money as double.

Starter Data

    int[] pattern = { 4, 4, 5, 5, 0, 6, 7, 3, 4, 5 }; // sum = 43  
    string category = "COMMERCIAL"; // change to test   `
Note: Repeating pattern 3× ⇒ monthlyUnits = 43 × 3 = 129, outageDays = 3.

Slab Calculation for 129 units
    
    First 100 @ 4.0 = ₹400
    Next 29 @ 6.0 = ₹174
    Total energy = ₹574
    Fixed (COMMERCIAL) = ₹150
    Outages > 0 ⇒ no rebate
    Grand Total = ₹724.00

Expected Output

    Category: COMMERCIAL | Units: 129 | Energy: ₹574.00 | Fixed: ₹150.00 | Rebate: ₹0.00 | Total: ₹724.00 | Outages: 3  

Stretch

1. Print a slab-wise line-item table.
2. Try DOMESTIC and confirm rebate triggers only when outageDays == 0.

Evaluation

1. Correct 30-day construction via loops
2. Accurate slab math & category handling
3. Proper conditional rebate logic