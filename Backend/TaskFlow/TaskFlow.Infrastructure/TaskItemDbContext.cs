using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Infrastructure.Entities.Models;

namespace TaskFlow.Infrastructure
{
    public class TaskItemDbContext : DbContext 
    {
        public TaskItemDbContext(DbContextOptions<TaskItemDbContext> options) : base(options)
        {
            
        }

        public DbSet<TaskItemEntity> TaskItem { get; set; }

    }
}
