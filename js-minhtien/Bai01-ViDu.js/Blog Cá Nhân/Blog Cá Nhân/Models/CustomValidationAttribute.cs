using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogManager.Models
{
    public class CustomValidationAttribute
    {
        [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
        public sealed class ValidDate : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value != null)
                {
                    DateTime _dateJoin = Convert.ToDateTime(value);

                    if (_dateJoin > DateTime.Now)
                    {
                        return new ValidationResult("Date can not be greater than current date.");
                    }
                }

                return ValidationResult.Success;
            }
        }
    }
}