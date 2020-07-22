using ASPPracticeAPI.Dtos;
using ASPPracticeAPI.Entities;
using ASPPracticeAPI.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPPracticeAPI.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private UserRepository _repository { get; set; }
        private IMapper _mapper { get; set; }
        public UsersController(UserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetUsers()
        {
            var users = _repository.GetUsers();
            return Ok(_mapper.Map<IEnumerable<UserDto>>(users));
        }
        [HttpPost]
        public ActionResult<UserDto> AddNewUser(AddUserDto userDto)
        {
            User user = _mapper.Map<User>(userDto);
            _repository.AddUser(user);
            return Ok(_mapper.Map<UserDto>(user));
        }
    }
}
