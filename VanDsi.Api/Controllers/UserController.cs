using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VanDsi.Core.DTOs;
using VanDsi.Core.Models;
using VanDsi.Core.Services;

namespace VanDsi.Api.Controllers
{
    public class UserController : CustomBaseController
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            return CreateActionResult(await _userService.GetAllAsync());
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetUser()
        {
            var claims = User.Claims;
            var userId = claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var userDto = _mapper.Map<UserDto>(_userService.GetUserById(int.Parse(userId)));

            //The existence of user information will be checked.
            return CreateActionResult(CustomResponseDto<UserDto>.Success(200, userDto));
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(UserDto userDto)
        {
            var userEntity = await _userService.AddAsync(_mapper.Map<User>(userDto));
            return CreateActionResult(CustomResponseDto<UserDto>.Success(204, _mapper.Map<UserDto>(userEntity)));
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UserDto userDto)
        {
            var userEntity = _mapper.Map<User>(userDto);
            await _userService.UpdateAsync(userEntity);
            return CreateActionResult(CustomResponseDto<UserDto>.Success(204, _mapper.Map<UserDto>(userEntity)));
        }

        [Authorize]
        [HttpGet("{id:int}")]
        public IActionResult GetUserById(int id)
        {
            return CreateActionResult(_userService.GetUserById(id));
        }

        [Authorize]
        [HttpGet("[action]")]
        public IActionResult GetUserByUserNameAndPassword(string userName, string password)
        {
            return CreateActionResult(_userService.GetUserByUserNameAndPassword(userName, password));
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> RemoveUserAsync(UserDto userDto)
        {
            var userEntity = _mapper.Map<User>(userDto);
            return CreateActionResult(await _userService.RemoveAsync(userEntity));
        }
    }
}
