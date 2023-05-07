using FullPizzApi.Data;
using FullPizzApi.Interfaces;
using FullPizzApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullPizzApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IPizza db;
        public PizzaController(IPizza db)
        {
            this.db = db;
        }
        [HttpGet]
        [Route("GetAllPizza")]
        public IActionResult GetAllPizza()
        {
            return Ok(db.GetPizza());
        }
        [Route("GetPizzaById/{id:int}")]
        [HttpGet]
        public IActionResult GetPizzaById(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            return Ok(db.GetPizzaById(id));
        }
        [Route("GetPizzaById/{FullName}")]
        [HttpGet]
        public IActionResult GetPizzaById(string FullName)
        {
            if (FullName == null)
            {
                return NotFound();
            }
            return Ok(db.GetPizzaByName(FullName));
        }
        [Route("AddPizza")]
        [HttpPost]
        public IActionResult AddPizza(Pizza pizza)
        {
            if (pizza == null)
            {
                return BadRequest();
            }
            db.AddPizza(pizza);
            return Ok("Was Added");
        }
        [Route("UpdatePizza")]
        [HttpPut]
        public IActionResult UpdatePizza(int id,Pizza pizza)
        {
            if(id ==0 || pizza.Id != id)
            {
                return NotFound();
            }
            db.GetPizzaById(id);
            if(pizza == null)
            {
                return BadRequest();
            }
            db.UpdatePizza(pizza);
            return Ok("Was Updated");
        }
        [Route("DeletePizza")]
        [HttpDelete]
        public IActionResult DeletePizza(int id)
        {
            if(id ==0 )
            {
                return NotFound();
            }
            db.DeletePizza(id);
            return Ok("Was Deleted");
        }


    }
}
