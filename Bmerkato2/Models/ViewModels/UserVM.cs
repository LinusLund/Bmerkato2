using Bmerkato2.Models.Identity;

namespace Bmerkato2.Models.ViewModels
{
    public class UserVM
    {

        public string Id { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Role { get; set; } = null!;

    }
}
