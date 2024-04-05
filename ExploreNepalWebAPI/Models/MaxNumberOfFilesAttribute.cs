using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace ImagesTesting.Models
{
    public class MaxNumberOfFilesAttribute : ValidationAttribute
    {
        private readonly int _maxNumberOfFiles;

        public MaxNumberOfFilesAttribute(int maxNumberOfFiles)
        {
            _maxNumberOfFiles = maxNumberOfFiles;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var files = value as List<IFormFile>;

            if (files == null || files.Count == 0)
            {
                return new ValidationResult("Please upload at least one image.");
            }

            if (files.Count > _maxNumberOfFiles)
            {
                return new ValidationResult($"You can upload a maximum of {_maxNumberOfFiles} images.");
            }

            return ValidationResult.Success;
        }
    }
}
