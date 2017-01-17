using System.Collections.Generic;
using System.Linq;

using HomeworkOrganiser.API.Models;

namespace HomeworkOrganiser.API.Repositories
{
    public class HomeworkRepository : RepositoryXml<Homework>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HomeworkOrganiser.API.Repositories.HomeworkRepository"/> class.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public HomeworkRepository(string fileName)
            : base(fileName)
        {

        }

        public List<Homework> GetAllByUserId(string userId)
        {
            return DataStore.Values.Where(x => x.UserId == userId).ToList();
        }

        /// <summary>
        /// Modifies the homework.
        /// </summary>
        /// <param name="homework">Homework.</param>
        public void Modify(Homework homework)
        {
            Homework oldHomework = Get(homework.Id);
            
            oldHomework.Title = homework.Title;
            oldHomework.Description = homework.Description;
            oldHomework.Deadline = homework.Deadline;
            oldHomework.Grade = homework.Grade;

            Save();
        }
    }
}