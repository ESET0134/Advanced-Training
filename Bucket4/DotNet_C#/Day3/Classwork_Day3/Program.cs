namespace Classwork_Day3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // list <typeofobj> name = new <datatype>();

            List<string> food = new List<string>();

            food.Add("Pizza");
            food.Add("Pasta");
            food.Add("Papad");

            food.Remove("fries");
            food.Insert(0, "sushi");
            Console.WriteLine(food.Count);
            Console.WriteLine(food.IndexOf("pizza"));

            foreach (string item in food)
            {
                Console.WriteLine(item);
            }
        }
    }
}
