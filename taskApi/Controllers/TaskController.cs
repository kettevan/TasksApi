using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using taskApi.Models;
using taskApi.Repositories;

namespace taskApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("Task")]
    public class TaskController :  ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet("Statuses")]
        public async Task<IActionResult> Statuses()
        {
            var result = _taskRepository.getStatuses();
            if (result != null)
            {
                return Ok(result.Result);
            }
            return Problem("No Result");
            
        }

        [HttpGet("Users")]
        public async Task<IActionResult> Users()
        {
            var result = _taskRepository.getUsers();
            if (result != null)
            {
                return Ok(result.Result);
            }
            return Problem("No Result");
        }

        [HttpGet("Tasks")]
        public async Task<IActionResult> Tasks()
        {
            var result = _taskRepository.getActiveTasks();
            
            if (result != null)
            {
                return Ok(result.Result);
            }
            return Problem("No Result");
        }


        [HttpPost("NewTask")]
        public async Task<IActionResult> NewTask([FromBody] TaskModel request)
        {
            var result = _taskRepository.createTask(request);
            if (result != null)
            {
                return Ok(result.Result);
            }
            return Problem("No Result");
        }

        [HttpGet("TaskById")]
        public async Task<IActionResult> TaskById(string id)
        {
            var result = _taskRepository.getTaskById(id);
            if (result != null)
            {
                return Ok(result.Result);
            }
            return Problem("No Result");
        }

        [HttpGet("StatusById")]
        public async Task<IActionResult> StatusById(string id)
        {
            var result = _taskRepository.StatusById(id);
            if (result != null)
            {
                return Ok(result.Result);
            }
            return Problem("No Result");
        }

        [HttpGet("NextStatus")]
        public async Task<IActionResult> NextStatus(string currStatus)
        {
            var result = _taskRepository.getNextStatus(currStatus);
            if (result != null)
            {
                return Ok(result.Result);
            }
            return Problem("No Result");
        }
    }
}
