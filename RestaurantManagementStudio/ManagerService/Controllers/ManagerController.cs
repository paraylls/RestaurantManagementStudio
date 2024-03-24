using AutoMapper;
using ManagerService.Data;
using ManagerService.Dtos;
using ManagerService.Models;
using Microsoft.AspNetCore.Mvc;

namespace ManagerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : Controller
    {
        private readonly IManagerRepo _repository;
        private readonly IMapper _mapper;

        public ManagerController(IMapper mapper, IManagerRepo repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ManagerReadDto>> GetAllManagers()
        {
            Console.WriteLine("---> Getting Managers...");

            var managers = _repository.GetAllManagers();

            return Ok(_mapper.Map<IEnumerable<ManagerReadDto>>(managers));
        }

        [HttpGet("{id}", Name = "GetManagersById")]
        public ActionResult<ManagerReadDto> GetManagerById(int id)
        {
            var manager = _repository.GetManagerById(id);
            if (manager != null)
            {
                return Ok(_mapper.Map<ManagerReadDto>(manager));
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<ManagerReadDto> CreateManager(ManagerCreateDto managerCreateDto)
        {
            var managerModel = _mapper.Map<ManagerModel>(managerCreateDto);
            _repository.CreateManager(managerModel);
            _repository.SaveChanges();

            var managerReadDto = _mapper.Map<ManagerReadDto>(managerModel);

            return CreatedAtRoute(nameof(GetManagerById), new { Id = managerReadDto.Id }, managerReadDto);
        }
    }
}
