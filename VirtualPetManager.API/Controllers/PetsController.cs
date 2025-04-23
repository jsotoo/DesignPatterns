using Microsoft.AspNetCore.Mvc;
using VirtualPetManager.Application;
using VirtualPetManager.Application.Utils;
using VirtualPetManager.Domain;
using VirtualPetManager.Domain.Dtos;

namespace VirtualPetManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController: ControllerBase
    {
        private readonly IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_petService.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var pet = _petService.GetById(id);
            return pet == null ? NotFound() : Ok(pet);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Pet pet)
        {
            _petService.Create(pet);
            return CreatedAtAction(nameof(GetById), new { id = pet.Id }, pet);
        }

        [HttpPut("feed/{id}")]
        public IActionResult Feed(Guid id)
        {
            _petService.Feed(id);
            return NoContent();
        }

        [HttpPut("clean/{id}")]
        public IActionResult Clean(Guid id)
        {
            _petService.Clean(id);
            return NoContent();
        }

        [HttpPut("play/{id}")]
        public IActionResult Play(Guid id)
        {
            _petService.Play(id);
            return NoContent();
        }

        [HttpPost("bytype")]
        public IActionResult CreateByType([FromBody] PetRequestByType request)
        {
            try
            {
                _petService.CreateFromFactory(request.Name, request.Age, request.Type);
                return Ok("Mascota creada con Factory Method.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("builder")]
        public IActionResult CreateWithBuilder([FromBody] PetRequestByType request)
        {
            try
            {
                _petService.CreateWithBuilder(request.Name, request.Age, request.Type);
                return Ok("Mascota creada con Builder.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("logs")]
        public IActionResult GetLogs()
        {
            var logs = ActionLogger.Instance.GetLogs();
            return Ok(logs);
        }

        [HttpGet("decorate/{id}")]
        public IActionResult GetDecoratedPet(Guid id)
        {
            var description = _petService.GetDecoratedDescription(id);
            return Ok(description);
        }

        [HttpPut("care/{id}")]
        public IActionResult TakeCare(Guid id)
        {
            _petService.TakeCare(id);
            return Ok("La mascota ha sido cuidada (alimentada, jugada y bañada).");
        }
        
        [HttpPut("takecare")]
        public IActionResult TakeCare([FromBody] Pet pet)
        {
            _petService.TakeCare(pet);
            return Ok($"{pet.Name} ha sido alimentado, jugado y bañado.");
        }

        [HttpPut("play/{id}/{type}")]
        public IActionResult Play(Guid id, string type)
        {
            try
            {
                _petService.Play(id, type);
                return Ok($"Mascota jugó usando estrategia: {type}");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
