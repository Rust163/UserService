using UserService.Models;
using UserService;
using Microsoft.AspNetCore.Mvc;
namespace UserService.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class Controller<T> : ControllerBase where T : class {
        private readonly IRepository<T> _repository;
        public Controller(IRepository<T> repository) { 
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) {
                return NotFound();
            }
            else { 
             return Ok(entity);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var entities = await _repository.GetAllAsync();
            return Ok(entities);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Add([FromBody] T entity) {
            await _repository.AddAsync(entity);
            return Ok($"{typeof(T).Name} успешно добален!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] T entity) {
            await _repository.UpdateAsync(entity);
            return Ok($"{typeof(T).Name} успешно обнавлен!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            await _repository.DeleteAsync(id);
            return Ok($"{typeof(T).Name} успешно удален!");
        }
    }
}
