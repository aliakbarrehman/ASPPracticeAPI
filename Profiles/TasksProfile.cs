using ASPPracticeAPI.Dtos;
using ASPPracticeAPI.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ASPPracticeAPI.Profiles
{
    public class TasksProfile : Profile
    {
        public TasksProfile()
        {
            CreateMap<Task, TaskDto>();
            CreateMap<AddTaskDto, Task>();
        }
    }
}
