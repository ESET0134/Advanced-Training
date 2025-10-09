namespace College_App.Model
{
    public class collegeRepository
    {
        public static List<Student> students { get; set; } = new List<Student>()
        { 
            new Student
            {
                studentID = 1,
                name = "Test",
                age = 1,
                email = "shivam@gmail.com"
            },
            new Student 
            {
                studentID = 2,
                name = "Test",
                age = 2,
                email = "dsckjbdsc"
            }

        };
    }
}
