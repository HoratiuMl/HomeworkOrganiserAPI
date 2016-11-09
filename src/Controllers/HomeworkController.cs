using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using HomeworkOrganiser.API.Models;

namespace HomeworkOrganiser.API.Controllers
{
    [Route("api/[controller]")]
    public class HomeworkController : Controller
    {
        private static List<Homework> homeworks;
        static HomeworkController()
        {
            homeworks = new List<Homework>();
        }

        [HttpGet]
        public IEnumerable<Homework> GetAll()
        {
            return homeworks.AsReadOnly();
        }

        [HttpGet("{id}", Name = "GetHomework")]
        public IActionResult GetById(string id)
        {
            Homework item = homeworks.Find(n => n.Id == id);

            if (item == null)
                return NotFound();

            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Homework item)
        {
            if (item == null)
                return BadRequest();
            
            item.Id = (homeworks.Count + 1).ToString();
            homeworks.Add(item);

            return CreatedAtRoute("GetHomework", new { controller = "Homework", id = item.Id }, item);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            homeworks.RemoveAll(n => n.Id == id);
        }
    }
}
