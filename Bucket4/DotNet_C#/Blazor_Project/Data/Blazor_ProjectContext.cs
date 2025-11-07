using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Blazor_Project.Model;

namespace Blazor_Project.Data
{
    public class Blazor_ProjectContext : DbContext
    {
        public Blazor_ProjectContext (DbContextOptions<Blazor_ProjectContext> options)
            : base(options)
        {
        }

        public DbSet<Blazor_Project.Model.Student> Student { get; set; } = default!;
    }
}
