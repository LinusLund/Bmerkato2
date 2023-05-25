using Bmerkato2.Helpers.Services;
using Bmerkato2.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Bmerkato2.Controllers
{
    public class TagController : Controller
    {
        private readonly TagService _tagService;

        public TagController(TagService tagService)
        {
            _tagService = tagService;
        }

        
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AddTag()
        {
            var viewModel = new TagVM();
            var tags = await _tagService.GetAllTagsAsync();
            viewModel.Tags = tags.Select(tag => tag.TagName).ToList();
            return View(viewModel);
           
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AddTag(TagVM viewModel)
        {
            if (ModelState.IsValid)
            {
                var tagName = viewModel.TagName;
                var createdTag = await _tagService.CreateTagAsync(tagName);

                if (createdTag != null)
                {
                    return RedirectToAction("AddTag");
                }
                else
                {
                    ModelState.AddModelError("", "Failed to create the tag.");
                }
            }

            return View(viewModel);
        }


    }
}
