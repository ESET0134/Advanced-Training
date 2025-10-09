namespace CS._3._019
{
    public interface IBillingRule
    {
        double Compute(int units);
    }

    public class CommercialRule : IBillingRule
    {
        public double Compute(int units)
        {
            return (8.5 * units) + 150.0;
        }
    }

    public interface IRebate
    {
        string Code { get; }
        double Apply(double currentTotal, int units, int outageDays);
    }
    public class NoOutageRebate : IRebate
    {
        public string Code => "NO_OUTAGE -2%";
        public double Apply(double currentTotal, int units, int outageDays)
        {
            return outageDays == 0 ? currentTotal * -0.02 : 0;
        }
    }

    public class HighUsageRebate : IRebate
    {
        public string Code => "HIGH_USAGE -3%";
        public double Apply(double currentTotal, int units, int outageDays)
        {
            return units > 500 ? currentTotal * -0.03 : 0;
        }
    }
    public static class RebateProvider
    {
        public static List<IRebate> GetActiveRebates()
        {
            return new List<IRebate>
            {
                new NoOutageRebate(),
                new HighUsageRebate()
            };
        }
    }

    public class BillingContext
    {
        public IBillingRule Rule { get; }
        public List<IRebate> Rebates { get; }

        public BillingContext(IBillingRule rule, List<IRebate> rebates)
        {
            Rule = rule;
            Rebates = rebates;
        }

        public double Finalize(int units, int outageDays)
        {
            double total = Rule.Compute(units);
            foreach (var r in Rebates)
            {
                total += r.Apply(total, units, outageDays);
            }
            return total;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            IBillingRule commercialRule = new CommercialRule();
            List<IRebate> activeRebates = RebateProvider.GetActiveRebates();
            var context = new BillingContext(commercialRule, activeRebates);

            int units = 620;
            int outageDays = 0;

            double subtotal = commercialRule.Compute(units);
            double finalTotal = context.Finalize(units, outageDays);

            string rebateDescription = string.Join(" | ", activeRebates.Select(r => r.Code));

            Console.WriteLine($"Subtotal: INR 8.5 * {units} + 150 = INR {subtotal:N2}");
            Console.WriteLine($"Rebates: {rebateDescription}");
            Console.WriteLine($"Final: INR {finalTotal:N2}");
        }
    }
}