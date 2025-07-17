using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Domain.Entities.Models;
using TaskFlow.Domain.Repositories;
using TaskFlow.Domain.Services;

namespace TaskFlow.Application.Services
{
    public class TaskItemsService : ITaskItemsService
    {
        private readonly ITasksItemRepository _taskItemsRepository;

        public TaskItemsService(ITasksItemRepository tasksItemsRepository)
        {
            _taskItemsRepository = tasksItemsRepository;
        }

        public async Task<List<TaskItemModel>> GetAllTaskItems()
        {
            return await _taskItemsRepository.Get();
        }

        public async Task<Guid> CreateTaskItem(TaskItemModel taskItemModel)
        {
            return await _taskItemsRepository.Create(taskItemModel);
        }

        public async Task<Guid> UpdateTaskItem(Guid id, string title, string description, string author, DateTime startDate, DateTime endDate)
        {
            return await _taskItemsRepository.Update(id, title, description, author, startDate, endDate);
        }

        public async Task<Guid> DeleteTaskItem(Guid id)
        {
            return await _taskItemsRepository.Delete(id);
        }
    }
}
