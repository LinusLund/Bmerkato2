using Bmerkato2.Contexts;
using Bmerkato2.Models.Entities;
using Microsoft.EntityFrameworkCore;


namespace Bmerkato2.Helpers.Repos
{
    public class ProductRepository : Repo<ProductEntity>
    {

        private readonly DataContext _context;

        public ProductRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<ProductEntity>> GetAllAsync()
        {
            var products = await _context.Products.Include(x => x.ProductTags).ThenInclude(x => x.Tag).ToListAsync();
            return products;
        }
    }
}
