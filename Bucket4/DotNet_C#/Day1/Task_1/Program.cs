using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;

namespace Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Students Name:");
            string studentName = Console.ReadLine();

            Console.WriteLine("Enter Students Marks:");
            Console.WriteLine("Mathematics:");
            int mathematics = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Physics:");
            int physics = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Social Science:");
            int social = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Political Science:");
            int politics = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Foreign Language:");
            int foreignLanguage = Convert.ToInt32(Console.ReadLine());

            int totalMarks = mathematics + physics + social + politics + foreignLanguage;
            double averageMarks = totalMarks / 5.0;
            double percentage = (totalMarks / 500.0) * 100;

            Console.WriteLine("Student Details:");
            Console.WriteLine($"Student Name: {studentName}");
            Console.WriteLine("Results:");
            Console.WriteLine($"Total Marks: {totalMarks}");
            Console.WriteLine($"Average Marks: {averageMarks}");
            Console.WriteLine($"Percentage: {percentage}%");

            Console.ReadLine();
        }
    }
}
