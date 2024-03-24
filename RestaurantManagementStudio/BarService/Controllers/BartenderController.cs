using AutoMapper;
using BarService.Data;
using BarService.Dtos;
using BarService.Models;
using Microsoft.AspNetCore.Mvc;

namespace BarService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BartenderController : ControllerBase
    {
        private readonly IBartenderRepo _repository;
        private readonly IMapper _mapper;

        public BartenderController(IBartenderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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
        public ActionResult<BartenderReadDto> CreateBartender(BartenderCreateDto bartenderCreateDto)
        {

            var bartenderModel = _mapper.Map<BartenderModel>(bartenderCreateDto);
            _repository.CreateBartender(bartenderModel);
            _repository.SaveChanges();

            var bartenderReadDto = _mapper.Map<BartenderReadDto>(bartenderModel);

            return CreatedAtRoute(nameof(GetBartenderById), new { Id = bartenderReadDto.Id }, bartenderReadDto);

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