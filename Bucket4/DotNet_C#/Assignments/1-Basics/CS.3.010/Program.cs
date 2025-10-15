namespace CS._3._010
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] outageHours = new int[][]
            {
                new int[] { 1, 0, 0, 5, -2, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0, 0 },
                new int[] { 0, 4, 3, 0, 0, 0, 0 } 
            };

            string[] meterIds = { "MTR001", "MTR002", "MTR003" };

            Console.WriteLine("MeterID| Outage Hours    | Action");

            for (int i = 0; i < outageHours.Length; i++)
            {
                int total = 0;
                bool invalidData = false;
                int j = 0;
                while (j < outageHours[i].Length)
                {
                    if (outageHours[i][j] < 0)
                    {
                        invalidData = true;
                        break;
                    }
                    j++;
                }

                if (invalidData)
                {
                    Console.WriteLine($"{meterIds[i]} | Invalid Data");
                    continue;
                }

                for (int d = 0; d < outageHours[i].Length; d++)
                {
                    total += outageHours[i][d];
                }

                string action;
                if (total > 8)
                    action = "Escalate to field team";
                else if (total == 0)
                    action = "Stable";
                else
                    action = "Monitor";

                Console.WriteLine($"{meterIds[i]} | Outage Hours: {total} | Action: {action}");
            }
        }
    }
}
