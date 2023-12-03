using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResponsabilityController : ControllerBase
    {
        private readonly IResponsabilityRepository _responsabilityRepository;
        private readonly IMapper _mapper;
        public ResponsabilityController(IResponsabilityRepository responsabilityRepository, IMapper mapper)
        {
            _responsabilityRepository = responsabilityRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var responsability = await _responsabilityRepository.GetAllAsync();
            var responsabilityDTO = _mapper.Map<IList<ResponsabilityDTO>>(responsability);

            return
                HttpMessageOk(responsabilityDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var responsability = await _responsabilityRepository.GetByIdAsync(id);
            if(responsability == null) return NotFound();

            var responsabilityDTO = _mapper.Map<ResponsabilityDTO>(responsability);
            return
                HttpMessageOk(responsabilityDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ResponsabilityViewModel createModel)
        {
            if (!ModelState.IsValid) return HttpMessageError("Dados incorretos");

            var responsability = _mapper.Map<Responsibility>(createModel);
            var volunteering = _mapper.Map<Volunteering>(createModel);

            //responsability.Volunteering = volunteering;

            await _responsabilityRepository.CreateAsync(responsability, volunteering);

            var responsabilityDTO = _mapper.Map<ResponsabilityDTO>(responsability);
            return
                HttpMessageOk(responsabilityDTO);
       
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ResponsabilityViewModel model)
        {
            if (!ModelState.IsValid) return HttpMessageError("Dados incorretos");

            var responsability = _mapper.Map<Responsibility>(model);
            responsability.Id = id;
            await _responsabilityRepository.UpdateAsync(responsability);

            var responsabilityDTO = _mapper.Map<ResponsabilityDTO>(responsability);
            return
                HttpMessageOk($"Responsability ID: {id}. DELETADO!");
        }






        private IActionResult HttpMessageOk(dynamic data = null)
        {
            if (data == null)
                return NoContent();
            else
                return Ok(new { data });
        }

        private IActionResult HttpMessageError(string message = "")
        {
            return BadRequest(new { message });
        }
    }
}