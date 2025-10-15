using System.Text;

namespace CS._1._001
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write("Enter meter serial number: ");
            string meterSerial = Console.ReadLine();

            int prevReading;
            while (true)
            {
                Console.Write("Enter previous meter reading (int): ");
                if (int.TryParse(Console.ReadLine(), out prevReading) && prevReading >= 0)
                {
                    break;
                }
                Console.WriteLine("Invalid input. Please enter a non-negative integer.");
            }

            int currReading;
            while (true)
            {
                Console.Write("Enter current meter reading (int): ");
                if (int.TryParse(Console.ReadLine(), out currReading) && currReading >= 0)
                {
                    if (currReading < prevReading)
                    {
                        Console.WriteLine("Invalid input. Current reading cannot be less than the previous reading.");
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a non-negative integer.");
                }
            }

            int units = currReading - prevReading;

            if (units <= 0)
            {
                Console.WriteLine("Error: Units consumed must be greater than 0.");
            }
            else
            {
                double energyCharge = units * 6.5;
                double taxRate = 0.05;
                double tax = energyCharge * taxRate;
                double total = energyCharge + tax;

                if (units > 500)
                {
                    Console.WriteLine("High usage alert: Consider reducing your energy consumption.");
                }

                Console.WriteLine(
                    $"Meter: {meterSerial} | Units: {units} | Energy: ₹{energyCharge:F2} | Tax(5%): ₹{tax:F2} | Total: ₹{total:F2}"
                );
            }
        }
    }
}
