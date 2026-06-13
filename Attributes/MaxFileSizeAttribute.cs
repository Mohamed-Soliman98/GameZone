using GameZone.Settings;

namespace GameZone.Attributes
{
    public class MaxFileSizeAttribute :ValidationAttribute
    {
        private readonly int _maxFileSize;

        public MaxFileSizeAttribute(int maxsize)
        {
            _maxFileSize = maxsize;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                
                if (file.Length > _maxFileSize)
                {
                    return new ValidationResult($"Maximum allowed size is {_maxFileSize} byes");
                }
            }
            return ValidationResult.Success;
            
        }
    }
}
