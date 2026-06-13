namespace GameZone.ViewModel
{
    public class EditGameFormVM : GameFormVM
    {
        public int Id { get; set; }

        public string? CurrentCover { get; set; }


        [Required(ErrorMessage = "Cover image is required")]
        [AllowedExtentions(Filesettings.AllowedExctentions)]
        [MaxFileSize(Filesettings.MaxFileSizeInBytes)]
        [Display(Name = "Cover Image")]
        public IFormFile? Cover { get; set; } = default!;
    }
}
