using TaskFlow.Domain.Entities.Models;

namespace TaskFlow.Domain.Repositories
{
    public interface ITasksItemRepository
    {
        Task<Guid> Create(TaskItemModel taskItem);
        Task<Guid> Delete(Guid id);
        Task<List<TaskItemModel>> Get();
        Task<Guid> Update(Guid id, string title, string description, string author, DateTime startDate, DateTime endDate);
    }
}