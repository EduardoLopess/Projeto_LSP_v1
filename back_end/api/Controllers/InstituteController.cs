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
    public class InstituteController : ControllerBase
    {
        private readonly IInstituteRepository _instituteRepository;
        private readonly IMapper _mapper;
        public InstituteController(IInstituteRepository instituteRepository, IMapper mapper)
        {
            _instituteRepository = instituteRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var institute = await _instituteRepository.GetAllAsync();
            var instituteDTO = _mapper.Map<IList<InstituteDTO>>(institute);

            return
                HttpMessageOk(instituteDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var institute = await _instituteRepository.GetByIdAsync(id);
            if(institute == null) return NotFound();

            var instituteDTO = _mapper.Map<InstituteDTO>(institute);
            return
                HttpMessageOk(instituteDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] InstituteViewModel createModel)
        {
            if (!ModelState.IsValid) return HttpMessageError("Dados incorretos");

            var institute = _mapper.Map<Institute>(createModel);
            var address = _mapper.Map<Address>(createModel.AdressViewModel);
            // var volunteering = _mapper.Map<List<Volunteering>>(createModel.VolunteeringViewModels);
            // var donationMaterial = _mapper.Map<List<DonationMaterial>>(createModel.DonationMaterialViewModels);
            
            institute.Address = address;
            // institute.Volunteerings = volunteering;
            // institute.DonationMaterials = donationMaterial;

            await _instituteRepository.CreateAsync(institute, address);
            var instituteDTO = _mapper.Map<InstituteDTO>(institute);
            return
                HttpMessageOk(instituteDTO);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, InstituteViewModel model)
        {
            if (!ModelState.IsValid) return HttpMessageError("Dados incorretos");
            var institute = _mapper.Map<Institute>(model);
            institute.Id = id;
            await _instituteRepository.UpdateAsync(institute);

            var instituteDTO = _mapper.Map<InstituteDTO>(institute);
            return
                HttpMessageOk(instituteDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var institute = await _instituteRepository.GetByIdAsync(id);
            if (institute == null) return NotFound();

            await _instituteRepository.DeleteAsync(id);
            return
                HttpMessageOk(id);
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