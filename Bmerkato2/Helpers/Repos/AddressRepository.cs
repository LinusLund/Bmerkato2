using Bmerkato2.Contexts;
using Bmerkato2.Models.Entities;

namespace Bmerkato2.Helpers.Repos
{
    public class AddressRepository : Repo<AddressEntity>
    {
        public AddressRepository(DataContext context) : base(context)
        {
        }
    }
}
