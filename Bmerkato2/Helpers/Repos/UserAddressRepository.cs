using Bmerkato2.Contexts;
using Bmerkato2.Models.Entities;

namespace Bmerkato2.Helpers.Repos
{
    public class UserAddressRepository : Repo<UserAddressEntity>
    {
        public UserAddressRepository(DataContext context) : base(context)
        {
        }
    }
}
