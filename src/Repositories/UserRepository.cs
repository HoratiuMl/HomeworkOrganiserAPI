using System;

using HomeworkOrganiser.API.Models;

namespace HomeworkOrganiser.API.Repositories
{
    public class UserRepository : RepositoryXml<User>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserOrganiser.API.Repositories.UserRepository"/> class.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public UserRepository(string fileName)
            : base(fileName)
        {

        }

        /// <summary>
        /// Modifies the user.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <param name="email">Email.</param>
        /// <param name="password">Password.</param> <summary>
        /// <param name="name">Name.</param>
        public void Modify(string id, string email, string password, string name)
        {
            User user = Get(id);
            
            user.EmailAddress = email;
            user.Password = password;
            user.Name = name;

            Save();
        }
    }
}