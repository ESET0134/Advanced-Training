namespace Task_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the time you wish to convert (in minutes):");
            int totalMinutes = Convert.ToInt32(Console.ReadLine());
            int hours = totalMinutes / 60;
            int minutes = totalMinutes % 60;

            Console.WriteLine("Total Minutes to Hours and minutes:");
            Console.WriteLine($"{hours} hours {minutes} minutes");
            Console.ReadLine();
        }
    }
}
