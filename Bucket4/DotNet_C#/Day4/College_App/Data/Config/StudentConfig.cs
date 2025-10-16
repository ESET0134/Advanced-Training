using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace College_App.Data.Config
{
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Student");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.Name).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Email).IsRequired();
            builder.Property(e => e.Age).IsRequired();
            builder.Property(e => e.City).IsRequired();
            builder.HasData(new List<Student>
            {
                new Student
                {
                    Id = 1,
                    Name = "Shruti",
                    Email = "shruti@gmail.com",
                    Age = 23,
                    City = "Blr"
                }
            });
        }
    }
}
