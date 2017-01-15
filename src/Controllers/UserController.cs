using System;
using System.Collections.Generic;
using System.Linq;

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
            
            userRepository.Add(user);

            return CreatedAtRoute("GetUser", new { controller = "User", id = user.Id }, user);
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
        public IEnumerable<User> GetAll()
        {
            RepositoryXml<User> userRepository = new RepositoryXml<User>(userXmlPath);
            
            return userRepository.GetAll();
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
            bool valid = false;

            if(user.Password == password)
            {
                valid = true;
            }

            return new ObjectResult(valid);
        }
    }
}
