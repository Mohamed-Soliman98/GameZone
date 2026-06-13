namespace GameZone.Attributes
{
    public class AllowedExtentionsAttribute : ValidationAttribute 
    {
        private readonly string _allowedExtentions;
        private int maxFillSizeInMB;

        public AllowedExtentionsAttribute(string allowedExtentions)
        {
            _allowedExtentions = allowedExtentions;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                var extention = Path.GetExtension(file.FileName);
                var IsAllowed = _allowedExtentions.Split(',').Contains(extention, StringComparer.OrdinalIgnoreCase);

                if (!IsAllowed)
                {
                    return new ValidationResult($"Only {_allowedExtentions} are allowed");
                }
            }

            return ValidationResult.Success;
        }
    }

    
}
