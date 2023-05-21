using Bmerkato2.Contexts;


namespace Bmerkato2.Helpers.Repos
{
    public class ProductCategoryRepository : Repo<ProductCategoryEntity>
    {
        public ProductCategoryRepository(DataContext context) : base(context)
        {
        }
    }
}
