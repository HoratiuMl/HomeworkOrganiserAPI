using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc;

using HomeworkOrganiser.API.Models;
using HomeworkOrganiser.API.Repositories;

namespace HomeworkOrganiser.API.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private string userXmlPath = "/home/horatiu/.homeworkorganiser/users.xml";

        /// <summary>
        /// Adds a new user
        /// </summary>
        /// <param name="user">User</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(string email, string password, string name)
        {
            RepositoryXml<User> userRepository = new RepositoryXml<User>(userXmlPath);
            User user = new User
            {
                Id = Guid.NewGuid().ToString(),
                EmailAddress = email,
                Name = name,
                Password = password
            };

            bool success = false;
            
            try
            {
                userRepository.Add(user);
                success = true;
            }
            catch
            {
                success = false;
            }

            return new ObjectResult (new { success });
        }

        /// <summary>
        /// Gets a user
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>The desired user</returns>
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            RepositoryXml<User> userRepository = new RepositoryXml<User>(userXmlPath);
            User user = userRepository.Get(id);

            return new ObjectResult(user);
        }

        /// <summary>
        /// Gets all userss
        /// </summary>
        /// <returns>All users</returns>
        [HttpGet]
        public IActionResult Get()
        {
            RepositoryXml<User> userRepository = new RepositoryXml<User>(userXmlPath);
            IEnumerable<User> users = userRepository.GetAll();

            return new ObjectResult(users);
        }

        /// <summary>
        /// Removes a user
        /// </summary>
        /// <param name="id">Identifier</param>
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            RepositoryXml<User> userRepository = new RepositoryXml<User>(userXmlPath);
            
            userRepository.Remove(id);

            return NoContent();
        }

        /// <summary>
        /// Logs in a user
        /// </summary>
        /// <param name="email">Email address</param>
        /// <param name="password">Password</param>
        /// <returns>True if the credentials are valid, false otherwise</returns>
        [HttpPost("login")]
        public IActionResult Login(string email, string password)
        {
            RepositoryXml<User> userRepository = new RepositoryXml<User>(userXmlPath);
            User user = userRepository.GetAll().FirstOrDefault(x => x.EmailAddress.ToLower() == email.ToLower());
            bool success = false;

            if (user?.Password == password)
            {
                success = true;
            }

            return new ObjectResult(new { success });
        }
    }
}
