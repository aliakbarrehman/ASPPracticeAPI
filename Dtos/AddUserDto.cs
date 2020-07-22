using ASPPracticeAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ASPPracticeAPI.Dtos
{
    public class AddUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<AddTaskDto> Tasks { get; set; } = new List<AddTaskDto>();
    }
}
