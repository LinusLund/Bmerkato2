using Bmerkato2.Models.Dtos;
using Bmerkato2.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Bmerkato2.Models.ViewModels
{
    public class TagVM
    {
        public int Id { get; set; }

        [Display(Name = "Tag Name")]
        [Required(ErrorMessage = "You must enter a Tag name")]
        public string TagName { get; set; } = null!;


        public List<string> Tags { get; set; } = new List<string>();


        public static implicit operator TagEntity(TagVM viewModel)
        {
            return new TagEntity
            {
                Id = viewModel.Id,
                TagName = viewModel.TagName,
            };
        }

       
    }
}
