namespace CS._2._008
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] daily = { 5.2, 6.8, 0.0, 7.5, 6.0, 4.8, 0.0 };

            double total = 0.0;
            int peakDays = 0;
            int outageDays = 0;

            for (int i = 0; i < daily.Length; i++)
            {
                double units = daily[i];
                total += units;

                if (units > 6.0)
                    peakDays++;

                if (units == 0.0)
                    outageDays++;
            }

            double avg = total / daily.Length;

            Console.WriteLine($"Total: {total:F1} kWh | Avg: {avg:F2} kWh | Peak Days (>6): {peakDays} | Outages: {outageDays}");

            bool stable = (outageDays <= 1) && (peakDays <= 2);
            string status = stable ? "Stable" : "Unstable";
            Console.WriteLine($"Performance Status: {status}");
        }
    }
}
