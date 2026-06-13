using GameZone.Attributes;
using GameZone.Settings;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.ViewModel
{
    public class CreateGameVM :GameFormVM
    {
        [Required(ErrorMessage = "Cover image is required")]
        [AllowedExtentions(Filesettings.AllowedExctentions)]
        [MaxFileSize(Filesettings.MaxFileSizeInBytes)]
        [Display(Name = "Cover Image")]
        public IFormFile Cover { get; set; } = default!;
    }
}