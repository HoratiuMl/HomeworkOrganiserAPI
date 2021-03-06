﻿﻿using System;

namespace HomeworkOrganiserAPI.Infrastructure.Exceptions
{
    /// <summary>
    /// Repository exception.
    /// </summary>
    public class EntityNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HomeworkOrganiserAPI.DAL.Repositories.DuplicateEntityException"/> class.
        /// </summary>
        public EntityNotFoundException()
            : base("Entity could not be found.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeworkOrganiserAPI.DAL.Repositories.EntityNotFoundException"/> class.
        /// </summary>
        /// <param name="entityId">Entity identifier.</param>
        public EntityNotFoundException(string entityId)
            : base($"{entityId} could not be found.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeworkOrganiserAPI.DAL.Repositories.EntityNotFoundException"/> class.
        /// </summary>
        /// <param name="entityId">Entity identifier.</param>
        /// <param name="innerException">Inner exception.</param>
        public EntityNotFoundException(string entityId, Exception innerException)
            : base($"{entityId} could not be found.", innerException)
        {
        }
    }
}
