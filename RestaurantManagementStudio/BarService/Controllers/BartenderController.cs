using BarService.Data;
using BarService.Models;
using Microsoft.AspNetCore.Mvc;

namespace BarService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BartenderController : ControllerBase
    {
        private readonly IBartenderRepo _repository;

        public BartenderController(IBartenderRepo repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetBartenders()
        {
            var bartenders = _repository.GetAllBartenders();
            return Ok(bartenders);
        }

        [HttpGet("{id}", Name = "GetBartenderById")]
        public IActionResult GetBartenderById(int id)
        {
            var bartender = _repository.GetBartenderById(id);
            if (bartender != null)
            {
                return Ok(bartender);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult CreateBartender(BartenderModel bartender)
        {
            _repository.CreateBartender(bartender);
            return CreatedAtRoute(nameof(GetBartenderById), new { id = bartender.Id }, bartender);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBartender(int id, BartenderModel bartender)
        {
            _repository.UpdateBartender(id, bartender);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBartender(int id)
        {
            _repository.DeleteBartender(id);
            return NoContent();
        }
    }
}