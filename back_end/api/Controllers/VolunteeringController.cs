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
    public class VolunteeringController : ControllerBase
    {
        private readonly IVolunteeringRepository _volunteeringRepository;
        private readonly IMapper _mapper;
        public VolunteeringController(IVolunteeringRepository volunteeringRepository, IMapper mapper)
        {
            _volunteeringRepository = volunteeringRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var volunteering = await _volunteeringRepository.GetAllAsync();
            var volunteeringDTO = _mapper.Map<IList<VolunteeringDTO>>(volunteering);

            return
                HttpMessageOk(volunteeringDTO);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var volunteering = await _volunteeringRepository.GetByIdAsync(id);
            if (volunteering == null) return NotFound();

            var volunteeringDTO = _mapper.Map<VolunteeringDTO>(volunteering);
            return
                HttpMessageOk(volunteeringDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] VolunteeringViewModel createModel)
        {
            if (!ModelState.IsValid) return HttpMessageError("Dados incorretos");

            var volunteering = _mapper.Map<Volunteering>(createModel);
            var benefits = _mapper.Map<IList<Benefit>>(createModel.BenefitViewModels);
            var responsibilities = _mapper.Map<IList<Responsibility>>(createModel.ResponsabilityViewModels);

            volunteering.Benefits = benefits;
            volunteering.Responsibility = responsibilities;
            await _volunteeringRepository.CreateAsync(volunteering, responsibilities, benefits);

            var volunteeringDTO = _mapper.Map<VolunteeringDTO>(volunteering);
            return
                HttpMessageOk(volunteeringDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, VolunteeringViewModel model)
        {
            if (!ModelState.IsValid) return HttpMessageError("Dados incorretos");
            var volunteering = _mapper.Map<Volunteering>(model);
            volunteering.Id = id;
            await _volunteeringRepository.UpdateAsync(volunteering);

            var volunteeringDTO = _mapper.Map<VolunteeringDTO>(volunteering);
            return
                HttpMessageOk(volunteeringDTO);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var volunteering = await _volunteeringRepository.GetByIdAsync(id);
            if(volunteering == null) return NotFound();

            await _volunteeringRepository.DeleteAsync(id);
            return
                HttpMessageOk($"Volunteering ID: {id}. DELETADO!");
        }



        // [HttpGet("volunteerings/summaries")]
        // public async Task<IActionResult> GetVolunteeringsSummaries()
        // {
        //     var volunteeringsSummaries = await _volunteeringRepository.GetSummaries(); // Método fictício para buscar informações resumidas

        //     // Mapear para um modelo resumido ou DTO se necessário
        //     var summaries = volunteeringsSummaries.Select(v => new
        //     {
        //         v.Id,
        //         v.Title,
        //         v.Description,
        //         v.Type,
        //         // Outras propriedades relevantes para os cards
        //     });

        //     return Ok(summaries);
        // }


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