using System.Security.Cryptography.X509Certificates;

namespace Classwork_day2
{
    static class Message
    {
        public static void Show()
        {
            Console.WriteLine("Hello, Shrutii!");
            Console.WriteLine("Good Morning");
        }
    }

    class human
    {
        public string name;
        public int age;

        public human(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
        public void eat()
        {
            Console.WriteLine($"{name} is eating IceCreammmm.");
        }
        public void sleep()
        {
            Console.WriteLine($"{name} is sleeping peacefully.");
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Message.Show();
            human person1 = new human("Shruti",23);
            person1.eat();
            person1.sleep();
            Console.WriteLine($"Name: {person1.name}, Age: {person1.age}");
            Console.ReadLine();
        }
    }
}
