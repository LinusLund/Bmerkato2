using Bmerkato2.Contexts;
using Bmerkato2.Models.Entities;

namespace Bmerkato2.Helpers.Repos
{
    public class ProductRepository : Repo<ProductEntity>
    {
        public ProductRepository(DataContext context) : base(context)
        {
        }
    }
}
