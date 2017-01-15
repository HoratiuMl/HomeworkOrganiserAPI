using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using HomeworkOrganiser.API.Models;
using HomeworkOrganiser.API.Repositories;

namespace HomeworkOrganiser.API.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private string userXmlPath = "/home/horatiu/.homeworkorganiser/users.xml";

        /// <summary>
        /// Gets all userss
        /// </summary>
        /// <returns>All users</returns>
        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            RepositoryXml<User> userRepository = new RepositoryXml<User>(userXmlPath);
            
            return userRepository.GetAll();
        }

        /// <summary>
        /// Gets a user
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>The desired user</returns>
        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult GetById(string id)
        {
            RepositoryXml<User> userRepository = new RepositoryXml<User>(userXmlPath);
            User user = userRepository.Get(id);

            return new ObjectResult(user);
        }

        /// <summary>
        /// Adds a new user
        /// </summary>
        /// <param name="user">User</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            RepositoryXml<User> userRepository = new RepositoryXml<User>(userXmlPath);
            
            userRepository.Add(user);

            return CreatedAtRoute("GetUser", new { controller = "User", id = user.Id }, user);
        }

        /// <summary>
        /// Removes a user
        /// </summary>
        /// <param name="id">Identifier</param>
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            RepositoryXml<User> userRepository = new RepositoryXml<User>(userXmlPath);
            
            userRepository.Remove(id);
        }
    }
}
