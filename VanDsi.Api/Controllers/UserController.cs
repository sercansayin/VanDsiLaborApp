using AutoMapper;
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

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            return CreateActionResult(await _userService.GetAllAsync());
        }

        [HttpPost]
        public IActionResult Save(UserDto userDto)
        {
            return CreateActionResult(_userService.AddUser(userDto));
        }

        [HttpPut]
        public IActionResult Update(UserDto userDto)
        {
            return CreateActionResult(_userService.UpdateUser(userDto));
        }

        [HttpGet("{id:int}")]
        public IActionResult GetUserById(int id)
        {
            return CreateActionResult(_userService.GetUserById(id));
        }

        [HttpGet]
        public IActionResult GetUserByUserNameAndPassword(string userName, string password)
        {
            return CreateActionResult(_userService.GetUserByUserNameAndPassword(userName, password));
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveUserAsync(UserDto userDto)
        {
            var userEntity = _mapper.Map<User>(userDto);
            return CreateActionResult(await _userService.RemoveAsync(userEntity));
        }
    }
}
