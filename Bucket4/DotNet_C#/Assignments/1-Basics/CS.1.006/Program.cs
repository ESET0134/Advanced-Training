namespace CS._1._006
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Previous Reading (kWh): ");
            double previous = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Current Reading (kWh): ");
            double current = Convert.ToDouble(Console.ReadLine());

            double consumption = current - previous;

            Console.WriteLine($"\nNet Consumption: {consumption} kWh");

            if (consumption < 0)
            {
                Console.WriteLine("Error: Invalid readings! (Current < Previous)");
            }
            else if (consumption == 0)
            {
                Console.WriteLine("Possible outage detected.");
            }
            else if (consumption > 500)
            {
                Console.WriteLine("High Consumption Alert!");
            }
            else if (consumption > 100 && consumption < 500)
            {
                Console.WriteLine("Normal usage.");
            }
            else
            {
                Console.WriteLine("Low usage.");
            }
        }
    }
}
