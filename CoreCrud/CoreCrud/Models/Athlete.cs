using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCrud.Models
{
    public class Athlete
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is compulsory")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Minimum 2-100 characters")]
        [CustomValidation(typeof(Athlete), "NameValidation")]
        [Display(Name = "Athlete Name")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Birthdate is compulsory")]
        [CustomValidation(typeof(Athlete), "ForBirthDate")]
        [DataType(DataType.Date)]
        [Display(Name = "Date Of Birth")]
        public DateTime BirthDate { get; set; }


        [Required(ErrorMessage = "It is compulsory")]
        [Display(Name = "Is US Citizen?")]
        public bool USCitizen { get; set; }


        [Required(ErrorMessage = "Weight is compulsory")]
        [Range(0, 1000, ErrorMessage = "Weight must be between 0-1000")]
        [Display(Name = "Weight")]
        public decimal Weight { get; set; }

    
        public decimal? Height { get; set; }

       
        public int NationalityID { get; set; }
        public Country Nationality { get; set; }
        public string Category
        {
            get
            {
                if (Weight > 150)
                {
                    return "Heavy";
                }
                else if (Weight > 145 && Weight < 150)
                    {
                    return "Medium";
                }
                else
                {
                    return "low";
                }
            }
        }

        public static ValidationResult NameValidation(string name, ValidationContext context)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return ValidationResult.Success;
            }
            var instance = context.ObjectInstance as Athlete;
            if (instance == null)
            {
                return ValidationResult.Success;
            }
            var dbContext = context.GetService(typeof(CoreCrudContext)) as CoreCrudContext;
            int duplicateCount = dbContext.Athlete
                              .Count(x => x.ID != instance.ID && x.Name == name);
            if (duplicateCount > 0)
            {
                return new ValidationResult($"Name {name} already exists");
            }
            return ValidationResult.Success;
        }

        public static ValidationResult ForBirthDate(DateTime? DateOfBirth, ValidationContext context)
        {
            if (DateOfBirth == null)
            {
                return ValidationResult.Success;
            }
            if (DateOfBirth < DateTime.Today)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Must be in past");
        }




    }
}
