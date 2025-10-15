namespace CS._3._004
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] meters = new int[][]
            {
                new[] { 4, 5, 0, 0, 6, 7, 3 },
                new[] { 2, 2, 2, 2, 2, 2, 2 },
                new[] { 9, 1, 1, 1, 1, 1, 1 } 
            };

            string[] ids = { "A-1001", "B-2001", "C-3001" };

            int globalMax = int.MinValue;
            int globalMeterIndex = -1;
            int globalDayIndex = -1;

            for (int i = 0; i < meters.Length; i++)
            {
                int total = 0;
                bool peakAlert = false;
                bool sustainedOutage = false;
                bool underutilization = false;

                int[] days = meters[i];
                int consecutiveZeros = 0;

                for (int d = 0; d < days.Length; d++)
                {
                    int usage = days[d];
                    total += usage;
                    if (usage > 8)
                        peakAlert = true;
                    if (usage == 0)
                    {
                        consecutiveZeros++;
                        if (consecutiveZeros >= 2)
                            sustainedOutage = true;
                    }
                    else
                    {
                        consecutiveZeros = 0;
                    }
                    if (usage > globalMax)
                    {
                        globalMax = usage;
                        globalMeterIndex = i;
                        globalDayIndex = d;
                    }
                }

                double avg = total / 7.0;
                if (avg < 2.0)
                    underutilization = true;

                Console.WriteLine(
                    $"{ids[i]} | Total:{total} Avg:{avg:F2} | " +
                    $"Peak:{(peakAlert ? "Yes" : "No")} | " +
                    $"SustainedOutage:{(sustainedOutage ? "Yes" : "No")} | " +
                    $"Underutilization:{(underutilization ? "Yes" : "No")}"
                );
            }

            Console.WriteLine(
                $"Highest Day: {globalMax} kWh | Meter: {ids[globalMeterIndex]} | Day: {globalDayIndex + 1}"
            );
        }
    }
}
