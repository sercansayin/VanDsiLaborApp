using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using VanDsi.Core.DTOs;
using VanDsi.Core.Models;
using VanDsi.Core.Repositories;
using VanDsi.Core.Services;
using VanDsi.Core.UnitOfWorks;
using VanDsi.Service.Security;

namespace VanDsi.Service.Services
{
    public class UserService:Service<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;


        public UserService(IUnitOfWork unitOfWork, IGenericRepository<User> repository, IUserRepository userRepository, IMapper mapper) : base(unitOfWork, repository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public CustomResponseDto<UserDto> GetUserById(int id)
        {
            var getUser = _userRepository.GetUserById(id);
            var userDto = _mapper.Map<UserDto>(getUser);
            return CustomResponseDto<UserDto>.Success(200,userDto);
        }

        public CustomResponseDto<UserDto> GetUserByUserNameAndPassword(string userName, string password)
        {
            var userPassword = Encryption.UserPassword(password);
            var getUser = _userRepository.GetUserByUserNameAndPassword(userName, userPassword);
            var userDto = _mapper.Map<UserDto>(getUser);
            return CustomResponseDto<UserDto>.Success(200, userDto);
        }

        public void SaveRefreshToken(int id, string refreshToken)
        {
            _userRepository.SaveRefreshToken(id,refreshToken);
            _unitOfWork.Commit();
        }

        public CustomResponseDto<UserDto> GetUserWithRefreshTokenByRefreshToken(string refreshToken)
        {
            var getUser = _userRepository.GetUserWithRefreshTokenByRefreshToken(refreshToken);
            var userDto = _mapper.Map<UserDto>(getUser);
            return CustomResponseDto<UserDto>.Success(200, userDto);
        }

        public void RemoveRefreshToken(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            _userRepository.RemoveRefreshToken(user);
            _unitOfWork.Commit();
        }
    }
}
