using System;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using HomeworkOrganiser.API.Models;
using HomeworkOrganiser.API.Repositories;

namespace HomeworkOrganiser.API.Controllers
{
    [Route("api/[controller]")]
    public class HomeworksController : Controller
    {
        private string homeworksXmlPath = "/home/horatiu/.homeworkorganiser/homeworks.xml";

        /// <summary>
        /// Adds a new homework
        /// </summary>
        /// <param name="homework">Homework</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(string title, string description, string deadline, int grade)
        {
            RepositoryXml<Homework> homeworkRepository = new RepositoryXml<Homework>(homeworksXmlPath);
            Homework homework = new Homework
            {
                Id = Guid.NewGuid().ToString(),
                Title = title,
                Description = description,
                Deadline = DateTime.Parse(deadline),
                Grade = grade
            };
            
            homeworkRepository.Add(homework);

            return CreatedAtRoute("GetHomework", new { controller = "Homework", id = homework.Id }, homework);
        }

        /// <summary>
        /// Gets a homework
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>The desired homework</returns>
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            RepositoryXml<Homework> homeworkRepository = new RepositoryXml<Homework>(homeworksXmlPath);
            Homework homework = homeworkRepository.Get(id);

            return new ObjectResult(homework);
        }

        /// <summary>
        /// Gets all homeworks
        /// </summary>
        /// <returns>All homeworks</returns>
        [HttpGet]
        public IActionResult Get()
        {
            RepositoryXml<Homework> homeworkRepository = new RepositoryXml<Homework>(homeworksXmlPath);
            IEnumerable<Homework> homeworks = homeworkRepository.GetAll();
            
            return new ObjectResult(homeworks);
        }

        /// <summary>
        /// Removes a homework
        /// </summary>
        /// <param name="id">Identifier</param>
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            RepositoryXml<Homework> homeworkRepository = new RepositoryXml<Homework>(homeworksXmlPath);
            
            homeworkRepository.Remove(id);
            
            return NoContent();
        }
    }
}
