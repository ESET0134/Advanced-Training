namespace CS._2._002
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] daily = { 4, 5, 6, 0, 7, 8, 5 };

            int total = 0;
            int maxUsage = -1;
            int maxDay = 0;
            int minUsage = int.MaxValue;
            int minDay = 0;
            int outages = 0;

            for (int i = 0; i < daily.Length; i++)
            {
                int currentKwh = daily[i];
                total += currentKwh;
                if (currentKwh == 0)
                {
                    outages++;
                }

                if (currentKwh > maxUsage)
                {
                    maxUsage = currentKwh;
                    maxDay = i + 1;
                }

                if (currentKwh > 0 && currentKwh < minUsage)
                {
                    minUsage = currentKwh;
                    minDay = i + 1;
                }
            }

            double average = (daily.Length > 0) ? (double)total / daily.Length : 0.0;
            Console.WriteLine(
                $"Total: {total} kWh | Avg: {average:F2} kWh | Max: {maxUsage} kWh (Day {maxDay}) | Outages: {outages}"
            );

            if (minDay > 0)
            {
                Console.WriteLine($"Min: {minUsage} kWh (Day {minDay})");
            }
        }
    }
}
