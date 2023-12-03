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
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var user = await _userRepository.GetAllAsync();
            var userDTO = _mapper.Map<IList<UserDTO>>(user);

            return
                HttpMessageOk(userDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if(user == null) return NotFound();

            var userDTO = _mapper.Map<UserDTO>(user);
            return
                HttpMessageOk(userDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] UserViewModel createModel)
        {
            if (!ModelState.IsValid) return HttpMessageError("Dados incorretos");

            var user = _mapper.Map<User>(createModel);
            var address = _mapper.Map<List<Address>>(createModel.AdressViewModels);

            user.Addresses = address;

            await _userRepository.CreateAsync(user, address.FirstOrDefault());
            
            var userDTO = _mapper.Map<UserDTO>(user);
            return
                HttpMessageOk(userDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update (int id, UserViewModel model)
        {
            if (!ModelState.IsValid) return HttpMessageError("Dados incorretos");
            var user = _mapper.Map<User>(model);
            user.Id = id;
            await _userRepository.UpdateAsync(user);

            var userDTO = _mapper.Map<UserDTO>(user);
            return
                HttpMessageOk(userDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return NotFound();

            await _userRepository.DeleteAsync(id);
            return 
                HttpMessageOk(id);
        }


        //EXTRAS
        // [HttpPost("subscribe")]
        // public async Task<IActionResult> SubscribeToVolunteering([FromBody] SubscriptionRequestModel subscription)
        // {

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