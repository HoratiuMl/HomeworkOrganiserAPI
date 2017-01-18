using System;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using HomeworkOrganiserAPI.Models;
using HomeworkOrganiserAPI.DAL.Repositories;

namespace HomeworkOrganiserAPI.Controllers
{
    /// <summary>
    /// Homeworks controller
    /// </summary>
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
        public IActionResult Post(string title, string userId, string description, string deadline, int grade)
        {
            HomeworkRepository homeworkRepository = new HomeworkRepository(homeworksXmlPath);
            Homework homework = new Homework
            {
                Id = Guid.NewGuid().ToString(),
                UserId = userId,
                Title = title,
                Description = description,
                Deadline = DateTime.Parse(deadline),
                Grade = grade
            };
            
            homeworkRepository.Add(homework);

            return CreatedAtRoute("GetHomework", new { controller = "Homework", id = homework.Id }, homework);
        }

        /// <summary>
        /// Gets all homeworks
        /// </summary>
        /// <returns>All homeworks</returns>
        [HttpGet]
        public IActionResult Get()
        {
            HomeworkRepository homeworkRepository = new HomeworkRepository(homeworksXmlPath);
            IEnumerable<Homework> homeworks = homeworkRepository.GetAll();
            
            return new ObjectResult(homeworks);
        }

        /// <summary>
        /// Gets all homeworks
        /// </summary>
        /// <returns>All homeworks</returns>
        [Route("ByUser")]
        [HttpGet("byuser/{userId}")]
        public IActionResult GetAllByUserId(string userId)
        {
            Console.WriteLine(userId);
            HomeworkRepository homeworkRepository = new HomeworkRepository(homeworksXmlPath);
            IEnumerable<Homework> homeworks = homeworkRepository.GetAllByUserId(userId);

            return new ObjectResult(homeworks);
        }

        /// <summary>
        /// Gets a homework
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>The desired homework</returns>
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            HomeworkRepository homeworkRepository = new HomeworkRepository(homeworksXmlPath);
            Homework homework = homeworkRepository.Get(id);

            return new ObjectResult(homework);
        }

        /// <summary>
        /// Updates a homework
        /// </summary>
        /// <param name="id">Identifier</param>
        [HttpPut("{id}")]
        public IActionResult Put(string id, string title, string description, string deadline, int grade)
        {
            HomeworkRepository homeworkRepository = new HomeworkRepository(homeworksXmlPath);
            Homework homework = homeworkRepository.Get(id);

            homework.Title = title;
            homework.Description = description;
            homework.Deadline = DateTime.Parse(deadline);
            homework.Grade = grade;

            homeworkRepository.Modify(homework);

            // TODO: Check if this is the proper response
            return NoContent();
        }

        /// <summary>
        /// Removes a homework
        /// </summary>
        /// <param name="id">Identifier</param>
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            HomeworkRepository homeworkRepository = new HomeworkRepository(homeworksXmlPath);
            
            homeworkRepository.Remove(id);
            
            return NoContent();
        }
    }
}
