using TaskFlow.Domain.Entities.Models;

namespace TaskFlow.Domain.Services
{
    public interface ITaskItemsService
    {
        Task<Guid> CreateTaskItem(TaskItemModel taskItemModel);
        Task<Guid> DeleteTaskItem(Guid id);
        Task<List<TaskItemModel>> GetAllTaskItems();
        Task<Guid> UpdateTaskItem(Guid id, string title, string description, string author, DateTime startDate, DateTime endDate);
    }
}