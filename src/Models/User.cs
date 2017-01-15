using System.ComponentModel.DataAnnotations;

namespace HomeworkOrganiser.API.Models
{
    public class User : EntityBase
    {
        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        /// <value>The email address.</value>
        [StringLength(32, ErrorMessage = "The {0} must be no longer than {1} characters")]
        public string EmailAddress { get; set; }
        
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [StringLength(32, ErrorMessage = "The {0} must be between {1} and {2} characters long", MinimumLength = 4)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        [StringLength(32, ErrorMessage = "The {0} must be between {1} and {2} characters long", MinimumLength = 8)]
        public string Password { get; set; }
    }
}
