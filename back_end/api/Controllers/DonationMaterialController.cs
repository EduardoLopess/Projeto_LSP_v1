using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DonationMaterialController : ControllerBase
    {
        private readonly IDonationMaterialRepository _donationMaterialRepository;
        private readonly IMapper _mapper;
        public DonationMaterialController(IDonationMaterialRepository donationMaterialRepository, IMapper mapper)
        {
            _donationMaterialRepository = donationMaterialRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var donationMaterial= await _donationMaterialRepository.GetAllAsync();
            var donationMaterialDTO = _mapper.Map<IList<DonationMaterialDTO>>(donationMaterial);

            return
                HttpMessageOk(donationMaterialDTO);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var donationMaterial = await _donationMaterialRepository.GetByIdAsync(id);
            if(donationMaterial == null) return NotFound();
            
            var donationMaterialDTO = _mapper.Map<DonationMaterialDTO>(donationMaterial);
            return
                HttpMessageOk(donationMaterialDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] DonationMaterialViewModel createModel)
        {
            if (!ModelState.IsValid) return HttpMessageError("Dados incorretos");

            var donationMaterial = _mapper.Map<DonationMaterial>(createModel);
            var donationPoint = _mapper.Map<DonationPoint>(createModel.DonationPointViewModel);
           //var institute = _mapper.Map<Institute>(createModel.InstituteViewModel);
            // var typeMaterial = _mapper.Map<TypeMaterial>(createModel.TypeMaterial);

            donationMaterial.DonationPoint = donationPoint;
            //donationMaterial.Institute = institute;
            
            await _donationMaterialRepository.CreateAsync(donationMaterial, donationPoint);
            
            var donationMaterialDTO = _mapper.Map<DonationMaterialDTO>(donationMaterial);
            return
                HttpMessageOk(donationMaterialDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DonationMaterialViewModel model)
        {
            if (!ModelState.IsValid) return HttpMessageError("Dados incorretos");
            var donationMaterial = _mapper.Map<DonationMaterial>(model);
            donationMaterial.Id = id;
            await _donationMaterialRepository.UpdateAsync(donationMaterial);

            var donationMaterialDTO = _mapper.Map<DonationMaterialDTO>(donationMaterial);
            return
                HttpMessageOk(donationMaterialDTO);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var donationMaterial = await _donationMaterialRepository.GetByIdAsync(id);
            if(donationMaterial == null) return NotFound();

            await _donationMaterialRepository.DeleteAsync(id);
            return
                HttpMessageOk($"DonationMaterial ID: {id}. DELETADO!");

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