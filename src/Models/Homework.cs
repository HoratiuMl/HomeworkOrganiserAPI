using System;
using System.ComponentModel.DataAnnotations;

namespace HomeworkOrganiser.API.Models
{
    public class Homework : EntityBase
    {
        [StringLength(32, ErrorMessage = "The {0} must be between {1} and {2} characters long", MinimumLength = 3)]
        public string Title { get; set; }
        
        [StringLength(256, ErrorMessage = "The {0} must be between {1} and {2} characters long", MinimumLength = 3)]
        public string Description { get; set; }

        public DateTime Deadline { get; set; }

        [Range(0, 10)]
        public int Grade { get; set; }
    }
}
