using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using HomeworkOrganiser.API.Models;

namespace HomeworkOrganiser.API.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private static List<User> users;

        /// <summary>
        /// 
        /// </summary>
        static UserController()
        {
            users = new List<User>();
        }

        /// <summary>
        /// Gets all userss
        /// </summary>
        /// <returns>All users</returns>
        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            return users.AsReadOnly();
        }

        /// <summary>
        /// Gets a user
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>The desired user</returns>
        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult GetById(string id)
        {
            User item = users.Find(n => n.Id == id);

            if (item == null)
                return NotFound();

            return new ObjectResult(item);
        }

        /// <summary>
        /// Adds a new user
        /// </summary>
        /// <param name="user">User</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            if (user == null)
                return BadRequest();
            
            user.Id = (users.Count + 1).ToString();
            users.Add(user);

            return CreatedAtRoute("GetUser", new { controller = "User", id = user.Id }, user);
        }

        /// <summary>
        /// Removes a user
        /// </summary>
        /// <param name="id">Identifier</param>
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            users.RemoveAll(n => n.Id == id);
        }
    }
}
