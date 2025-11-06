using DataAccess;
using Microsoft.AspNetCore.Components;

namespace First_Blazor.Components.Pages
{
    public class FirstBase : ComponentBase
    {
        public IEnumerable<Employee> Employees { get; set; }
        protected override Task OnInitializedAsync()
        {
            LoadEmployees();
            return base.OnInitializedAsync();
        }
        private void LoadEmployees()
        {
            Employees = new List<Employee>
            {
                new Employee { Id = 1, Name = "Alice Johnson", Position = "Developer" },
                new Employee { Id = 2, Name = "Bob Smith", Position = "Designer" },
                new Employee { Id = 3, Name = "Charlie Brown", Position = "Manager" }
            };
        }
    }
}
