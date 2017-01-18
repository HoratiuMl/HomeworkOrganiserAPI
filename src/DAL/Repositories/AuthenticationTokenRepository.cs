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
        public AuthenticationTokenRepository()
        {

        }

        public List<AuthenticationToken> GetAllByUserId(string userId)
        {
            return DataStore.Values.Where(x => x.UserId == userId).ToList();
        }
    }
}
