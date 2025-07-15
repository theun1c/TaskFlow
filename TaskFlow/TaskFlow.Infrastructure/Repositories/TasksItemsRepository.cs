using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Domain.Entities.Models;
using TaskFlow.Domain.Repositories;
using TaskFlow.Infrastructure.Entities.Models;

namespace TaskFlow.Infrastructure.Repositories
{
    public class TasksItemsRepository : ITasksItemRepository
    {
        private readonly TaskItemDbContext _dbContext;
        public TasksItemsRepository(TaskItemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TaskItemModel>> Get()
        {
            var taskItemEntities = await _dbContext.TaskItem
                .AsNoTracking()
                .ToListAsync();

            var taskItems = taskItemEntities
                .Select(t => TaskItemModel.Create(t.Id, t.Title, t.Description, t.Author, t.StartDate, t.EndDate).TaskItem)
                .ToList();

            return taskItems;
        }

        public async Task<Guid> Create(TaskItemModel taskItem)
        {
            var taskItemEntity = new TaskItemEntity
            {
                Id = taskItem.Id,
                Title = taskItem.Title,
                Description = taskItem.Description,
                Author = taskItem.Author,
                StartDate = taskItem.StartDate,
                EndDate = taskItem.EndDate,
            };

            _dbContext.TaskItem.AddAsync(taskItemEntity);
            _dbContext.SaveChangesAsync();

            return taskItemEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string title, string description, string author, DateTime startDate, DateTime endDate)
        {
            await _dbContext.TaskItem
                .Where(t => t.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(t => t.Title, t => title)
                    .SetProperty(t => t.Description, t => description)
                    .SetProperty(t => t.Author, t => author)
                    .SetProperty(t => t.StartDate, t => startDate)
                    .SetProperty(t => t.EndDate, t => endDate));
            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _dbContext.TaskItem
                .Where(t => t.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
