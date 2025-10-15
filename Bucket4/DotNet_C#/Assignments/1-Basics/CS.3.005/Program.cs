namespace CS._3._005
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] pattern = { 4, 4, 5, 5, 0, 6, 7, 3, 4, 5 };
            string category = "COMMERCIAL";

            int[] month = new int[30];
            for (int i = 0; i < 30; i++)
            {
                month[i] = pattern[i % pattern.Length];
            }

            int monthlyUnits = 0;
            int outageDays = 0;

            foreach (int units in month)
            {
                monthlyUnits += units;
                if (units == 0)
                    outageDays++;
            }

            double energyCharge = 0.0;
            int remaining = monthlyUnits;

            if (remaining > 0)
            {
                int first100 = Math.Min(100, remaining);
                energyCharge += first100 * 4.0;
                remaining -= first100;
            }

            if (remaining > 0)
            {
                int next200 = Math.Min(200, remaining);
                energyCharge += next200 * 6.0;
                remaining -= next200;
            }

            if (remaining > 0)
            {
                energyCharge += remaining * 8.5;
            }

            double fixedCharge = 0.0;
            switch (category.ToUpper())
            {
                case "DOMESTIC":
                    fixedCharge = 50.0;
                    break;
                case "COMMERCIAL":
                    fixedCharge = 150.0;
                    break;
                default:
                    Console.WriteLine("Unknown category.");
                    return;
            }

            double subtotal = energyCharge + fixedCharge;
            double rebate = (outageDays == 0) ? subtotal * 0.02 : 0.0;

            double total = subtotal - rebate;

            Console.WriteLine(
                $"Category: {category} | Units: {monthlyUnits} | " +
                $"Energy: ₹{energyCharge:F2} | Fixed: ₹{fixedCharge:F2} | " +
                $"Rebate: ₹{rebate:F2} | Total: ₹{total:F2} | Outages: {outageDays}"
            );

            Console.WriteLine("\n--- Slab Breakdown ---");
            Console.WriteLine("Slab\t\tRate\tUnits\tAmount");
            int unitsLeft = monthlyUnits;

            int slab1 = Math.Min(100, unitsLeft);
            Console.WriteLine($"0–100\t\t₹4.00\t{slab1}\t₹{slab1 * 4.0:F2}");
            unitsLeft -= slab1;

            int slab2 = Math.Min(200, Math.Max(0, unitsLeft));
            if (slab2 > 0)
                Console.WriteLine($"101–300\t\t₹6.00\t{slab2}\t₹{slab2 * 6.0:F2}");
            unitsLeft -= slab2;

            if (unitsLeft > 0)
                Console.WriteLine($"301+   \t\t₹8.50\t{unitsLeft}\t₹{unitsLeft * 8.5:F2}");

        }
    }
}
