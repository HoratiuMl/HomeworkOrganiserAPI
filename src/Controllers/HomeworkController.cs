using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using HomeworkOrganiser.API.Models;

namespace HomeworkOrganiser.API.Controllers
{
    [Route("api/[controller]")]
    public class HomeworkController : Controller
    {
        private static List<Homework> homeworks;

        /// <summary>
        /// 
        /// </summary>
        static HomeworkController()
        {
            homeworks = new List<Homework>();
        }

        /// <summary>
        /// Gets all homeworks
        /// </summary>
        /// <returns>All homeworks</returns>
        [HttpGet]
        public IEnumerable<Homework> GetAll()
        {
            return homeworks.AsReadOnly();
        }

        /// <summary>
        /// Gets a homework
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>The desired homework</returns>
        [HttpGet("{id}", Name = "GetHomework")]
        public IActionResult GetById(string id)
        {
            Homework item = homeworks.Find(n => n.Id == id);

            if (item == null)
                return NotFound();

            return new ObjectResult(item);
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
            
            homework.Id = (homeworks.Count + 1).ToString();
            homeworks.Add(homework);

            return CreatedAtRoute("GetHomework", new { controller = "Homework", id = homework.Id }, homework);
        }

        /// <summary>
        /// Removes a homework
        /// </summary>
        /// <param name="id">Identifier</param>
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            homeworks.RemoveAll(n => n.Id == id);
        }
    }
}
