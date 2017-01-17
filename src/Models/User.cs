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

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to the current <see cref="HomeworkOrganiser.API.Models.EntityBase"/>.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with the current <see cref="HomeworkOrganiser.API.Models.EntityBase"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="System.Object"/> is equal to the current
        /// <see cref="HomeworkOrganiser.API.Models.EntityBase"/>; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            User other = obj as User;
            
            if (other != null &&
               (other.Id == Id || other.EmailAddress == EmailAddress))
               {
                   return true;
               }
            
            return false;
        }

        /// <summary>
        /// Serves as a hash function for a <see cref="HomeworkOrganiser.API.Models.EntityBase"/> object.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a
        /// hash table.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
