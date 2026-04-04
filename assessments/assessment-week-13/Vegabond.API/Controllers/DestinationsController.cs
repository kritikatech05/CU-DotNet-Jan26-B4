using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vegabond.API.Exceptions;
using Vegabond.API.Models;
using Vegabond.API.Repositories;

namespace Vegabond.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DestinationsController : ControllerBase
    {
        private readonly IDestinationRepository _repo;

        public DestinationsController(IDestinationRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repo.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var dest = await _repo.GetByIdAsync(id);
            if (dest == null)
                throw new DestinationNotFoundException($"Destination {id} not found");

            return Ok(dest);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Destination destination)
        {
            await _repo.AddAsync(destination);
            return CreatedAtAction(nameof(GetById), new { id = destination.Id }, destination);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Destination destination)
        {
            if (id != destination.Id)
                return BadRequest();

            await _repo.UpdateAsync(destination);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repo.DeleteAsync(id);
            return NoContent();
        }
    }
}
