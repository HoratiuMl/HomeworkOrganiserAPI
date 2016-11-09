using System;

namespace HomeworkOrganiser.API.Exceptions
{
    /// <summary>
    /// Repository exception.
    /// </summary>
    public class RepositoryException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HomeworkOrganiser.API.Exceptions.RepositoryException"/> class.
        /// </summary>
        public RepositoryException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeworkOrganiser.API.Exceptions.RepositoryException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        public RepositoryException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeworkOrganiser.API.Exceptions.RepositoryException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerException">Inner exception.</param>
        public RepositoryException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
