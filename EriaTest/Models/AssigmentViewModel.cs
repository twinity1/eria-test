using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using EriaTest.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EriaTest.Models
{
    public class AssigmentViewModel : IValidatableObject
    {
        public IQueryable<Assigment> Assigments { get; set; }

        public List<AssigmentType> AssigmentTypes { get; set; } = new();
        
        [Required]
        [BindProperty]
        public string Title { get; set; }
     
        [Required]
        [BindProperty]
        public DateTime Start { get; set; } = DateTime.Now;
        
        [Required]
        [BindProperty]
        public DateTime End { get; set; } = DateTime.Now.AddMinutes(30);
        
        [Required]
        [Display(Name = "Type")]
        [BindProperty]
        public int? TaskTypeId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var result = new List<ValidationResult>();

            if (Start > End)
            {
                result.Add(new ValidationResult("The start date was be lower than the end date.", new []{nameof(Start)}));
            }

            if (AssigmentTypes.Any(x => x.Id == TaskTypeId) == false)
            {
                result.Add(new ValidationResult("Type is required.", new []{nameof(TaskTypeId)}));
            }

            return result;
        }
    }
}