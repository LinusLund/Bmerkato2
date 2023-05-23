
using Bmerkato2.Helpers.Repos;
using Bmerkato2.Models.Dtos;
using Bmerkato2.Models.Entities;

namespace Bmerkato2.Helpers.Services
{
    public class TagService
    {
        private readonly TagRepository _tagRepo;

        public TagService(TagRepository tagrepo)
        {
            _tagRepo = tagrepo;
        }


        //Create Tag
        public async Task<Tag> CreateTagAsync(string tagName)
        {
            var entity = new TagEntity { TagName = tagName };
            var result = await _tagRepo.AddAsync(entity);

            return result;
        }

        public async Task<Tag> GetTagAsync(string tagName)
        {
            var result = await _tagRepo.GetAsync(x=>x.TagName == tagName);
            return result;
        }

        public async Task<IEnumerable<Tag>> GetAllTagsAsync()
        {
            var result = await _tagRepo.GetAllAsync();

            
            var list = new List<Tag>();
            foreach (var tag in result)
                list.Add(tag);

            return list;
        }

        public async Task<Tag>UpdateTagAsync(Tag tag)
        {
            var entity = await _tagRepo.GetAsync(x => x.TagName == tag.TagName);
            if (entity != null)
            {
                entity.TagName = tag.TagName;
                var result = await _tagRepo.UpdateAsync(entity);
                return result;
            }
            return null!;
        }

        public async Task<bool> DeleteTagAsync(int Id)
        {
            var entity = await _tagRepo.GetAsync(x => x.Id == Id);
            return await _tagRepo.DeleteAsync(entity);
      
        }
    }
}
