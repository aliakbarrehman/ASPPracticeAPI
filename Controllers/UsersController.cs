using ASPPracticeAPI.Dtos;
using ASPPracticeAPI.Entities;
using ASPPracticeAPI.Helpers;
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
        /// <summary>
        /// Get all the authors
        /// </summary>
        /// <param name="userQuery">Page size and page number as part of query string</param>
        /// <returns>Number of total items and items in current page</returns>
        [HttpGet]
        public ActionResult<PagedResponse<UserDto>> GetUsers([FromQuery] UserQueryParameters userQuery)
        {
            var users = _repository.GetUsers(userQuery);
            var result = new PagedResponse<UserDto>
            {
                TotalItems = users.TotalItems,
                Items = _mapper.Map<IEnumerable<UserDto>>(users.Items)
            };
            return Ok(result);
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
