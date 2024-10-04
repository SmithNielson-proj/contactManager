using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ContactManager.Models
{
    public class Contacts
    {
        // properties for Id
        public int Id { get; set; }

        // properties and validation for FirstName
        [Required(ErrorMessage = "Please enter First Name.")]
        public string First { get; set; } = string.Empty;

        // properties and validation for LastName
        [Required(ErrorMessage = "Please enter Last Name.")]
        public string Last { get; set; } = string.Empty;

        // properties and validation for Phone number
        [Required(ErrorMessage = "Please enter Phone Number.")]
        public string Phone { get; set; } = string.Empty;

        // properties and validation for email 
        [Required(ErrorMessage = "Please enter Email.")]
        public string Email { get; set; } = string.Empty;

        // properties for dateTime
        public DateTime DateTime { get; set; }

        //Properties and validation for category 
        [Required(ErrorMessage = "Please enter a Category.")]
        public string CategoryId { get; set; } = string.Empty;

        // properties and no validation for category
        [ValidateNever]
        public Category Category { get; set; } = null!;

        // property and NO validation for category since it can be null
        public string? Organization { get; set; }

        // properties to format slug 
        public string Slug =>
            First?.Replace(' ', '-').ToLower() + '-' + Last?.ToString();
    }
}






