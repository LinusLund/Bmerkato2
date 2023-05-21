using Bmerkato2.Contexts;
using Bmerkato2.Models.Entities;

namespace Bmerkato2.Helpers.Repos
{
    public class TagRepository : Repo<TagEntity>
    {
        public TagRepository(DataContext context) : base(context)
        {
        }
    }
}
