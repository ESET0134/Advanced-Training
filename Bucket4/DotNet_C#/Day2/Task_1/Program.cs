namespace Task_1
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsIssued { get; private set; }
        public Book(int bookId, string title, string author)
        {
            BookId = bookId;
            Title = title;
            Author = author;
            IsIssued = false;
        }

        public void IssueBook()
        {
            if (!IsIssued)
            {
                IsIssued = true;
                Console.WriteLine($"The book '{Title}' has been issued.");
            }
            else
            {
                Console.WriteLine($"The book '{Title}' is already issued.");
            }
        }

        public void ReturnBook()
        {
            if (IsIssued)
            {
                IsIssued = false;
                Console.WriteLine($"The book '{Title}' has been returned.");
            }
            else
            {
                Console.WriteLine($"The book '{Title}' is not currently issued.");
            }
        }

        public void DisplayBookDetails()
        {
            Console.WriteLine("\n--- Book Details ---");
            Console.WriteLine($"ID: {BookId}");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Status: {(IsIssued ? "Issued" : "Available")}");
            Console.WriteLine("--------------------");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book(1, "The Hobbit", "J.R.R. Tolkien");
            Book book2 = new Book(2, "The Lord of the Rings", "J.R.R. Tolkien");
            Book book3 = new Book(3, "Pride and Prejudice", "Jane Austen");

            // Display initial details of all books.
            Console.WriteLine("Initial Status:");
            book1.DisplayBookDetails();
            book2.DisplayBookDetails();
            book3.DisplayBookDetails();

            // Simulate issuing and returning books.
            Console.WriteLine("\n--- Simulating Transactions ---");

            // Issue book1.
            book1.IssueBook();

            // Try to issue book1 again (should show a message).
            book1.IssueBook();

            // Issue book3.
            book3.IssueBook();

            // Return book1.
            Console.WriteLine("\nReturning The Hobbit...");
            book1.ReturnBook();

            // Try to return book1 again (should show a message).
            Console.WriteLine("\nReturning The Lord of the Rings...");
            book2.ReturnBook();

            // Display final status of all books.
            Console.WriteLine("\n--- Final Status ---");
            book1.DisplayBookDetails();
            book2.DisplayBookDetails();
            book3.DisplayBookDetails();

        }
    }
}
