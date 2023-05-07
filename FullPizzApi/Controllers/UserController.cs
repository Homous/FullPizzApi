using FullPizzApi.Interfaces;
using FullPizzApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullPizzApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser db;
        public UserController(IUser db)
        {
            this.db = db;        
        }
        [HttpGet]
        [Route("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            return Ok(db.GetUsers());
        }
        [HttpGet]
        [Route("GetUserById/{id:int}")]
        public IActionResult GetUserById(int id)
        {
            if(id == 0)
            {
                return NotFound();
            }
            return Ok(db.GetUserById(id));
        }
        [HttpGet]
        [Route("GetUserByName/{name}")]
        public IActionResult GetUserByName(string name) 
        {
            if(name == null)
            {
                return NotFound();
            }
            return Ok(db.GetUserByName(name));
        }
        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser(User user)
        {
            if(user == null)
            {
                return BadRequest();
            }
            db.AddUser(user);
            return Ok("Was Added");
        }
        [HttpPut]
        [Route("UpdateUser")]
        public IActionResult UpdateUser(User user)
        {
            if(user == null)
            {
                return BadRequest();
            }
            db.UpdateUser(user);
            return Ok("Was Updated");
        }
        [HttpDelete]
        [Route("DeleteUser")]
        public IActionResult DeleteUser(int id)
        {
            if(id == 0)
            {
                return NotFound();
            }
            db.DeleteUser(id);
            return Ok("Was Deleted");
        }

    }
}
