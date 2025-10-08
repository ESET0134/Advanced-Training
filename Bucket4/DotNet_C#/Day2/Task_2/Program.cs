namespace Task_2
{
    public class Movie
    {
        // Fields
        public string MovieName { get; set; }
        public int TotalSeats { get; }
        public int BookedSeats { get; private set; }

        public Movie(string movieName, int totalSeats)
        {
            MovieName = movieName;
            TotalSeats = totalSeats;
            BookedSeats = 0;
        }

        public void BookSeats(int numberOfSeats)
        {
            if (numberOfSeats <= 0)
            {
                Console.WriteLine("Invalid number of seats. Please enter a positive number.");
            }
            else if (BookedSeats + numberOfSeats > TotalSeats)
            {
                Console.WriteLine($"\nBooking failed for '{MovieName}'. Not enough seats available.");
                DisplayAvailableSeats();
            }
            else
            {
                BookedSeats += numberOfSeats;
                Console.WriteLine($"\n{numberOfSeats} seats successfully booked for '{MovieName}'.");
                DisplayAvailableSeats();
            }
        }

        public void CancelSeats(int numberOfSeats)
        {
            if (numberOfSeats <= 0)
            {
                Console.WriteLine("Invalid number of seats. Please enter a positive number.");
            }
            else if (BookedSeats - numberOfSeats < 0)
            {
                Console.WriteLine($"\nCancellation failed for '{MovieName}'. You cannot cancel more seats than are currently booked.");
                Console.WriteLine($"Current booked seats: {BookedSeats}.");
            }
            else
            {
                BookedSeats -= numberOfSeats;
                Console.WriteLine($"\n{numberOfSeats} seats successfully canceled for '{MovieName}'.");
                DisplayAvailableSeats();
            }
        }

        // Method to display available seats.
        public void DisplayAvailableSeats()
        {
            int availableSeats = TotalSeats - BookedSeats;
            Console.WriteLine($"Movie: {MovieName}");
            Console.WriteLine($"Total Seats: {TotalSeats}");
            Console.WriteLine($"Booked Seats: {BookedSeats}");
            Console.WriteLine($"Available Seats: {availableSeats}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a movie object.
            Movie movie1 = new Movie("The Martian", 50);

            Console.WriteLine("--- Welcome to the Movie Ticket Booking System ---");

            // Display initial available seats.
            movie1.DisplayAvailableSeats();

            // Simulate booking seats.
            movie1.BookSeats(10);
            movie1.BookSeats(20);
            movie1.BookSeats(8);
            movie1.BookSeats(15);// Failed booking (more than available).

            // Simulate canceling seats.
            movie1.CancelSeats(5); // Successful cancellation.
            movie1.CancelSeats(50); // Failed cancellation (more than booked).

            // Display final available seats.
            Console.WriteLine("\n--- End of Simulation ---");
            movie1.DisplayAvailableSeats();
        }
    }
}
