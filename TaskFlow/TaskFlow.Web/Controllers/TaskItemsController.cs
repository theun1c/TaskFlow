using Microsoft.AspNetCore.Mvc;
using TaskFlow.Domain.Entities.Models;
using TaskFlow.Domain.Services;
using TaskFlow.Web.Contracts.Requests;
using TaskFlow.Web.Contracts.Responses;

namespace TaskFlow.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskItemsController : ControllerBase
    {
        private readonly ITaskItemsService _taskItemsService;
        public TaskItemsController(ITaskItemsService taskItemsService)
        {
            _taskItemsService = taskItemsService;
        }

        [HttpGet("GetTaskItems")]
        public async Task<ActionResult<List<TaskItemsResponse>>> GetTaskItems()
        {
            var taskItems = await _taskItemsService.GetAllTaskItems();

            var response = taskItems.Select(t => new TaskItemsResponse(t.Id, t.Title, t.Description, t.Author, t.StartDate, t.EndDate));
            
            return Ok(response);
        }

        [HttpPost("CreateTaskItem")]
        public async Task<ActionResult<Guid>> CreateTaskItem([FromBody] TaskItemsRequest request)
        {
            var (taskItem, error) = TaskItemModel.Create(Guid.NewGuid(), request.Title, request.Description, request.Author, request.StartDate, request.EndDate);

            if (!string.IsNullOrEmpty(error)) 
                return BadRequest(error);

            var taskItemId = await _taskItemsService.CreateTaskItem(taskItem);

            return Ok(taskItemId);
        }

        [HttpDelete("DeleteTaskItem/{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteTaskItem(Guid id)
        {
            var taskItemId = await _taskItemsService.DeleteTaskItem(id);

            return Ok(taskItemId);
        }

        [HttpPut("UpdateTaskItem/{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateTaskItem(Guid id, [FromBody] TaskItemsRequest request)
        {
            var taskItemId = await _taskItemsService.UpdateTaskItem(id, request.Title, request.Description, request.Author, request.StartDate, request.EndDate);

            return Ok(taskItemId);
        }
    }
}
