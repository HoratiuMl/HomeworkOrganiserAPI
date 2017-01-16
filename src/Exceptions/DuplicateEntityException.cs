using System;

namespace HomeworkOrganiser.API.Exceptions
{
    /// <summary>
    /// Duplicate entity exception.
    /// </summary>
    public class DuplicateEntityException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HomeworkOrganiser.API.Repositories.DuplicateEntityException"/> class.
        /// </summary>
        public DuplicateEntityException()
            : base("Entity already exists.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeworkOrganiser.API.Repositories.DuplicateEntityException"/> class.
        /// </summary>
        /// <param name="entityId">Entity identifier.</param>
        public DuplicateEntityException(string entityId)
            : base($"{entityId} already exists.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeworkOrganiser.API.Repositories.DuplicateEntityException"/> class.
        /// </summary>
        /// <param name="entityId">Entity identifier.</param>
        /// <param name="innerException">Inner exception.</param>
        public DuplicateEntityException(string entityId, Exception innerException)
            : base($"{entityId} already exists.", innerException)
        {
        }
    }
}
