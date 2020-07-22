using System;
using System.Collections.Generic;
using System.Linq;
using ASPPracticeAPI.Dtos;
using ASPPracticeAPI.Entities;
using ASPPracticeAPI.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPPracticeAPI.Controllers
{
    [Route("api/users/{userId}/tasks")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private TaskRepository _repository { get; set; }
        private IMapper _mapper { get; set; }
        public TasksController(TaskRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<TaskDto>> GetTasks(int userId)
        {
            var tasks = _repository.GetTasks(userId);
            return Ok(_mapper.Map<IEnumerable<TaskDto>>(tasks));
        }
        [HttpPost]
        public ActionResult<TaskDto> AddNewUser(int userId, AddTaskDto taskDto)
        {
            Task task = _mapper.Map<Task>(taskDto);
            task.UserId = userId;
            _repository.AddTask(task);
            return Ok(_mapper.Map<TaskDto>(task));
        }
    }
}