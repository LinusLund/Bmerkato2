using Bmerkato2.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Bmerkato2.Models.ViewModels
{
        public class ContactFormVM
        {
            [Display(Name = "Name")]
            [MinLength(2, ErrorMessage = "Your name need to be atleast 2 characters long")]
            [Required(ErrorMessage = "Please fill in a name")] //Ändrar på errormeddelande vid failad registrering
            [RegularExpression(@"^[a-öA-Ö]+(?:[ é'-][a-öA-Ö]+)*$", ErrorMessage = "You need to fill in a valid Name")] //Regex  First+lastname
            public string Name { get; set; } = null!;


            [Display(Name = "Email")]
            [Required(ErrorMessage = "Please fill in an Email")]
            [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "You need to fill in a valid email")] //Regex email RFC 6531
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; } = null!;


            [Display(Name = "Phonenumber")]
            public string? PhoneNumber { get; set; }


            [Display(Name = "Company Name")]
            public string? Company { get; set; }


            [Display(Name = "Comment")]
            [RegularExpression(@"^[a-öA-Ö]+(?:[ é'-][a-öA-Ö]+)*$", ErrorMessage = "Invalid comment.")]
            [Required(ErrorMessage = "Please fill in a comment")]
            public string Comment { get; set; } = null!;




            [Display(Name = "Save my name, email in the this browser for the next time I comment.")]
            public bool SaveMyData { get; set; } = false!;


        public static implicit operator ContactFormEntity(ContactFormVM viewModel)
        {
            return new ContactFormEntity
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                PhoneNumber = viewModel.PhoneNumber,
                Company = viewModel.Company,
                Comment = viewModel.Comment,
                RememberMe = viewModel.SaveMyData,
                DateTime = DateTime.Now
            };
        }
    }
    
}
