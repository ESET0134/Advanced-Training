using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using Collage_App.Model.Validators;

namespace College_App.Model
{
    public class studentDTO
    {
        [ValidateNever]
        public int studentID { get; set; }
        [Required(ErrorMessage ="Please enter the name")]
        [StringLength(100)]
        [CapitalCase]
        public string name { get; set; }
        [Range(10,30)]
        public int age { get; set; }
        [EmailAddress(ErrorMessage ="write correct email")]
        public string email { get; set; }
        [SpaceCheck]
        public string password { get; set; }
        [Compare(nameof(password))]
        public string reenterpassword { get; set; }

    }
}
