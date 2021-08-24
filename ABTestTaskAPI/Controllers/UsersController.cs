using ABTestTaskAPI.Data;
using ABTestTaskAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ABTestTaskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepo repository;
        public UsersController(IUsersRepo repo)
        {
            repository = repo;
        }

        // GET: api​/Users
        [HttpGet]
        public IEnumerable<User> GetAllUsers()
        {
            return repository.GetAllUsers();
        }

        // GET: api​/Users/{id}
        [HttpGet]
        [Route("{id}")]
        public User GetUserById(int id)
        {
            return repository.GetUserById(id);
        }

        // POST: api/Post
        [HttpPost]
        public ActionResult<User> AddOrUpdateUser(User user)
        {
            repository.AddOrUpdateUser(user);
            repository.SaveChanges();
            return Ok();
        }
    }
}
