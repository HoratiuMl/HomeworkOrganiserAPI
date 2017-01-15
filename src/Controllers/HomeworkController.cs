using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using HomeworkOrganiser.API.Models;
using HomeworkOrganiser.API.Repositories;

namespace HomeworkOrganiser.API.Controllers
{
    [Route("api/[controller]")]
    public class HomeworkController : Controller
    {
        private string homeworksXmlPath = "/home/horatiu/.homeworkorganiser/homeworks.xml";

        /// <summary>
        /// Gets all homeworks
        /// </summary>
        /// <returns>All homeworks</returns>
        [HttpGet]
        public IEnumerable<Homework> GetAll()
        {
            RepositoryXml<Homework> homeworkRepository = new RepositoryXml<Homework>(homeworksXmlPath);
            
            return homeworkRepository.GetAll();
        }

        /// <summary>
        /// Gets a homework
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>The desired homework</returns>
        [HttpGet("{id}", Name = "GetHomework")]
        public IActionResult GetById(string id)
        {
            RepositoryXml<Homework> homeworkRepository = new RepositoryXml<Homework>(homeworksXmlPath);
            
            return new ObjectResult(homeworkRepository.Get(id));
        }

        /// <summary>
        /// Adds a new homework
        /// </summary>
        /// <param name="homework">Homework</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create([FromBody] Homework homework)
        {
            if (homework == null)
                return BadRequest();
            
            RepositoryXml<Homework> homeworkRepository = new RepositoryXml<Homework>(homeworksXmlPath);
            
            homework.Id = "hw" + (homeworkRepository.Size + 1).ToString();
            homeworkRepository.Add(homework);
            
            return CreatedAtRoute("GetHomework", new { controller = "Homework", id = homework.Id }, homework);
        }

        /// <summary>
        /// Removes a homework
        /// </summary>
        /// <param name="id">Identifier</param>
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            RepositoryXml<Homework> homeworkRepository = new RepositoryXml<Homework>(homeworksXmlPath);
            
            homeworkRepository.Remove(id);
        }
    }
}
