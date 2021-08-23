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

        // GET: api/<UsersController>
        [Route("[controller]/[action]")]
        [HttpGet]
        public IEnumerable<User> GetAllUsers()
        {
            return repository.GetAllUsers();
        }

        [HttpGet]
        [Route("[controller]/[action]")]
        public User GetUserById(int id)
        {
            return repository.GetUserById(id);
        }

        // POST api/<UsersController>
        [HttpPost]
        public ActionResult<User> CreateNewUser(IEnumerable<User> newUsers)
        {
            foreach (var user in newUsers)
            {
                if (GetUserById(user.Id) != null)
                {
                    ModelState.AddModelError("Id", $"Id {user.Id} уже существует в бд");
                    return BadRequest(ModelState);
                }
                repository.CreateNewUser(user);
            }
            repository.SaveChanges();
            return Ok();
        }
    }
}
