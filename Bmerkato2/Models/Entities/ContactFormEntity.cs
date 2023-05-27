using Bmerkato2.Models.Dtos;

namespace Bmerkato2.Models.Entities
{
    public class ContactFormEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? Company { get; set; }
        public string Comment { get; set; } = null!;
        public bool RememberMe { get; set; }
        public DateTime DateTime { get; set; }


        public static implicit operator ContactFormData(ContactFormEntity formData)
        {
            return new ContactFormEntity
            {
                Id = formData.Id,
                Name = formData.Name,
                Email = formData.Email,
                PhoneNumber = formData.PhoneNumber,
                Company = formData.Company,
                Comment = formData.Comment,
                RememberMe = formData.RememberMe,
                DateTime = DateTime.Now
            };
        }
    }
}
