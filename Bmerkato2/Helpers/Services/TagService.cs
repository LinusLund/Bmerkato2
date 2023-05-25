
using Bmerkato2.Helpers.Repos;
using Bmerkato2.Models.Dtos;
using Bmerkato2.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        public async Task<IEnumerable<TagEntity>> GetAllTagsAsync()
        {
            var result = await _tagRepo.GetAllAsync();
            return result;
        }

        public async Task<List<SelectListItem>> GetTagsAsync(string[] selectedTags)
        {
            var tags = new List<SelectListItem>();

            foreach (var tag in await _tagRepo.GetAllAsync())
            {
                tags.Add(new SelectListItem
                {
                    Value = tag.Id.ToString(),
                    Text = tag.TagName,
                    Selected = selectedTags.Contains(tag.Id.ToString())
                });
            }
            return tags;
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
