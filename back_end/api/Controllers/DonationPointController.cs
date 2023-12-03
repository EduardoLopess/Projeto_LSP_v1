using AutoMapper;
using Data.Repository;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DonationPointController : ControllerBase
    {
        private readonly IDonationPointRepository _donationPointRepository;
        private readonly IMapper _mapper;
        public DonationPointController(IDonationPointRepository donationPointRepository, IMapper mapper)
        {
            _donationPointRepository = donationPointRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var donationPoint = await _donationPointRepository.GetAllAsync();
            var donationPointDTO = _mapper.Map<IList<DonationPointDTO>>(donationPoint);

            return
                HttpMessageOk(donationPointDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var donationPoint = await _donationPointRepository.GetByIdAsync(id);
            if (donationPoint == null) return NotFound();

            var donationPointDTO = _mapper.Map<DonationMaterialDTO>(donationPoint);
            return
                HttpMessageOk(donationPointDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] DonationPointViewModel createModel)
        {
            if(!ModelState.IsValid) return HttpMessageError("Dados Incorretos");

            var donationPoint = _mapper.Map<DonationPoint>(createModel);
            var address = _mapper.Map<Address>(createModel.AdressViewModel);
            // var institute = _mapper.Map<Institute>(createModel.InstituteViewModel);
            var donationMaterial = _mapper.Map<IList<DonationMaterial>>(createModel.DonationMaterialViewModels);

            donationPoint.Address = address;
            //donationPoint.Institute = institute;
            donationPoint.DonationMaterials = donationMaterial;

            await _donationPointRepository.CreateAsync(donationPoint, address, donationMaterial);

            var donationPointDTO = _mapper.Map<DonationPointDTO>(donationPoint);
            return
                HttpMessageOk(donationPointDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DonationMaterialViewModel model)
        {
            if (!ModelState.IsValid) return HttpMessageError("Dados incorretos");
            var donationPoint = _mapper.Map<DonationPoint>(model);
            donationPoint.Id = id;
            await _donationPointRepository.UpdateAsync(donationPoint);

            var donationPointDTO = _mapper.Map<DonationPointDTO>(donationPoint);
            return
                HttpMessageOk(donationPointDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var donationPoint = await _donationPointRepository.GetByIdAsync(id);
            if (donationPoint == null) return NotFound();

            await _donationPointRepository.DeleteAsync(id);
            return
                HttpMessageOk($"DonationPoint ID: {id}. DELETADO! ");
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