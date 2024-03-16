using System;
using Microsoft.AspNetCore.Mvc;
using api_train_orm.Models;
using api_train_orm.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_train_orm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly PizzaService _PizzaService;

        public PizzaController(PizzaService pizzaService) => _PizzaService = pizzaService;
        // GET: api/<PizzaController>
        [HttpGet]
        public async Task<List<Pizza>> GetAll() => await _PizzaService.GetAsync();

        // GET api/<PizzaController>/5
        [HttpGet("{id}")]
        public async Task<Pizza> Get(string id) => await _PizzaService.Get(id);

        // POST api/<PizzaController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Pizza value) {
            await _PizzaService.Add(value);
            return CreatedAtAction(nameof(Get), new { id = value.Id }, value);
        }

        // PUT api/<PizzaController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody] Pizza value)
        {
            var pizza = await _PizzaService.Get(id);

            if (pizza is null)
            {
                return NotFound();
            }

            value.Id = pizza.Id;

            await _PizzaService.Update(value);

            return NoContent();
        }

        // DELETE api/<PizzaController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var pizza = _PizzaService.Get(id);

            if (pizza is null)
            {
                return NotFound();
            }

            await _PizzaService.Delete(id);

            return NoContent();
        }
    }
}
