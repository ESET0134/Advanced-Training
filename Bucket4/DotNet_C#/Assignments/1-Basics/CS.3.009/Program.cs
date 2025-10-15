namespace CS._3._009
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] status = { "OK", "OUTAGE", "TAMPER", "OK", "OUTAGE", "OK", "LOW_VOLT" };

            int okCount = 0;
            int outageCount = 0;
            int tamperCount = 0;
            int lowVoltCount = 0;

            bool suspiciousPattern = false;

            string prev = "";

            foreach (string s in status)
            {
                switch (s.ToUpper())
                {
                    case "OK":
                        okCount++;
                        break;
                    case "OUTAGE":
                        outageCount++;
                        break;
                    case "TAMPER":
                        tamperCount++;
                        if (prev == "OUTAGE")
                            suspiciousPattern = true;
                        break;
                    case "LOW_VOLT":
                        lowVoltCount++;
                        break;
                    default:
                        Console.WriteLine($"Unknown status: {s}");
                        break;
                }

                prev = s;
            }

            Console.Write($"OK: {okCount} | OUTAGE: {outageCount} | TAMPER: {tamperCount} | LOW_VOLT: {lowVoltCount}  ");

            if (outageCount > 2 || tamperCount > 1)
            {
                Console.Write("Maintenance required");
            }
            else
            {
                Console.Write("Meter healthy");
            }

            if (suspiciousPattern)
            {
                Console.Write(" | Suspicious Pattern detected");
            }

            Console.WriteLine();
        }
    }
}
