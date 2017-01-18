using System.ComponentModel.DataAnnotations;

namespace HomeworkOrganiserAPI.Models
{
    /// <summary>
    /// Authentication token entity.
    /// </summary>
    public class AuthenticationToken : EntityBase
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        [StringLength(40, ErrorMessage = "The {0} must be between {1} and {2} characters long", MinimumLength = 3)]
        public string UserId { get; set; }
    }
}
