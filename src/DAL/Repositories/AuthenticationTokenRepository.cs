using System.Collections.Generic;
using System.Linq;

using HomeworkOrganiserAPI.Models;

namespace HomeworkOrganiserAPI.DAL.Repositories
{
    public class AuthenticationTokenRepository : Repository<AuthenticationToken>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HomeworkOrganiserAPI.DAL.Repositories.AuthenticationToken"/> class.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public AuthenticationToken(string fileName)
            : base(fileName)
        {

        }

        public List<Homework> GetAllByUserId(string userId)
        {
            return DataStore.Values.Where(x => x.UserId == userId).ToList();
        }
    }
}
