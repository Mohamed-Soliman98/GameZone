namespace GameZone.ViewModel
{
    public class GameFormVM
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(250, ErrorMessage = "Name cannot exceed 250 characters")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select a category")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();

        [Required(ErrorMessage = "Please select at least one device")]
        [Display(Name = "Supported Devices")]
        public List<int> SelectedDevices { get; set; } = default!;
        public IEnumerable<SelectListItem> Devices { get; set; } = Enumerable.Empty<SelectListItem>();

        [Required(ErrorMessage = "Description is required")]
        [MaxLength(3000, ErrorMessage = "Description cannot exceed 3000 characters")]
        [MinLength(20, ErrorMessage = "Description must be at least 20 characters")]
        public string Description { get; set; } = string.Empty;

       
    }
}
