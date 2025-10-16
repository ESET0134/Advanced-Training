using System;
using System.Collections.Generic;

namespace Student_Database.Models;

public partial class Course
{
    public int Id { get; set; }

    public int Rank { get; set; }

    public string CourseName { get; set; } = null!;
}
