using System.Text;

namespace CS._2._007
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string meterCategory = "COMMERCIAL";
            double units = 120;

            double rate = 0.0;
            double totalBill = 0.0;

            switch (meterCategory.ToUpper())
            {
                case "DOMESTIC":
                    rate = 6.0;
                    break;

                case "COMMERCIAL":
                    rate = 8.5;
                    break;

                case "AGRICULTURE":
                    rate = 3.0;
                    break;

                default:
                    Console.WriteLine("Unknown category. Check configuration.");
                    return;
            }

            totalBill = units * rate;
            Console.WriteLine($"Category: {meterCategory} | Rate: ₹{rate} | Total Bill: ₹{totalBill:F2}");

        }
    }
}
