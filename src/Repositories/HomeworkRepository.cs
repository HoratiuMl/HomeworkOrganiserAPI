using System;

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

        /// <summary>
        /// Modifies the homework.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <param name="title">Title.</param>
        /// <param name="description">Description.</param> <summary>
        /// <param name="grade">Grade.</param>
        public void Modify(string id, string title, string description, DateTime deadline, int grade)
        {
            Homework homework = Get(id);
            
            homework.Title = title;
            homework.Description = description;
            homework.Deadline = deadline;
            homework.Grade = grade;

            Save();
        }
    }
}