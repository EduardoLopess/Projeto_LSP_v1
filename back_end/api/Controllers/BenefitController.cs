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
    public class BenefitController : ControllerBase
    {
        private readonly IBenefitRepository _benefitRepository;
        private readonly IMapper _mapper;
        public BenefitController(IBenefitRepository benefitRepository, IMapper mapper)
        {
            _benefitRepository = benefitRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var benefit = await _benefitRepository.GetAllAsync();
            var benefitDTO = _mapper.Map<IList<BenefitDTO>>(benefit);

            return
                HttpMessageOk(benefitDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var benefit = await _benefitRepository.GetByIdAsync(id);
            if (benefit == null) return NotFound();

            var benefitDTO = _mapper.Map<BenefitDTO>(benefit);
            return
                HttpMessageOk(benefitDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] BenefitViewModel createModel)
        {
            if (!ModelState.IsValid) return HttpMessageError("Dados incorretos");
            
            var benefit = _mapper.Map<Benefit>(createModel);
            var volunteering = _mapper.Map<Volunteering>(createModel);

            // benefit.Volunteering = volunteering;
            
            await _benefitRepository.CreateAsync(benefit, volunteering);

            var benefitDTO = _mapper.Map<BenefitDTO>(benefit);
            return
                HttpMessageOk(benefitDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, BenefitViewModel model)
        {
            if (!ModelState.IsValid) return HttpMessageError("Dados incorretos");

            var benefit = _mapper.Map<Benefit>(model);
            benefit.Id = id;
            await _benefitRepository.UpdateAsync(benefit);

            var benefitDTO = _mapper.Map<BenefitDTO>(benefit);
            return
                HttpMessageOk(benefitDTO);
           
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var benefit = await _benefitRepository.GetByIdAsync(id);
            if(benefit == null) return NotFound();

            await _benefitRepository.DeleteAsync(id);
            return
                HttpMessageOk($"Benefit ID: {id}. DELETADO!");
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
    
