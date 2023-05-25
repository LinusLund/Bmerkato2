using Bmerkato2.Contexts;
using Bmerkato2.Models.Entities;

namespace Bmerkato2.Helpers.Repos
{
    public class ContactFormRepository : Repo<ContactFormEntity>
    {
        public ContactFormRepository(DataContext context) : base(context)
        {
        }
    }
}
