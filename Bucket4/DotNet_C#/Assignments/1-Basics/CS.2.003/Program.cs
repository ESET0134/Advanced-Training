using System.Text;

namespace CS._2._003
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            string[] lines = {
                "2025-09-01,4.2,OK",
                "2025-09-02,5.0,OK",
                "2025-09-03,0.0,OUTAGE",
                "2025-09-04,3.8,OK",
                "2025-09-05,6.1,OK",
                "2025-09-06,2.5,TAMPER",
                "2025-09-07,5.4,OK"
            };
            double okKwhSum = 0.0;
            int okCount = 0;
            int outageCount = 0;
            int tamperCount = 0;

            double maxOkKwh = -1.0;
            string busiestOkDay = "";

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 3)
                {
                    string date = parts[0];
                    if (double.TryParse(parts[1], out double kwh))
                    {
                        string status = parts[2];

                        if (status.Equals("OK", StringComparison.OrdinalIgnoreCase))
                        {
                            okKwhSum += kwh;
                            okCount++;

                            if (kwh > maxOkKwh)
                            {
                                maxOkKwh = kwh;
                                busiestOkDay = date;
                            }
                        }
                        else if (status.Equals("OUTAGE", StringComparison.OrdinalIgnoreCase))
                        {
                            outageCount++;
                        }
                        else if (status.Equals("TAMPER", StringComparison.OrdinalIgnoreCase))
                        {
                            tamperCount++;
                        }
                    }
                }
            }
            double okAverage = (okCount > 0) ? okKwhSum / okCount : 0.0;

            Console.WriteLine($"OK: {okKwhSum:F2} kWh (avg {okAverage:F2}) | OUTAGE: {outageCount} | TAMPER: {tamperCount}");

            if (!string.IsNullOrEmpty(busiestOkDay))
            {
                Console.WriteLine($"Busiest OK day: {busiestOkDay} with {maxOkKwh:F2} kWh");
            }
        }
    }
}
