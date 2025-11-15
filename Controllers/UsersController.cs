using EmailApp.Models;
using EmailApp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EmailApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRepository<User> _repository;
        public UsersController(IRepository<User> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            await _repository.DeleteAsync(id);
            return Ok(new {Success = "true"});        
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(User user)
        {
            if (user == null) return BadRequest("User is null");

            await _repository.UpdateAsync(user);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            if (user == null) return BadRequest("User is null");
            await _repository.CreateAsync(user);
            return CreatedAtAction(nameof(Get), new {id = user.Id}, user);
        }
    }
}