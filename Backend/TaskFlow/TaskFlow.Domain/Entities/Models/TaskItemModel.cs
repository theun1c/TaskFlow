using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Domain.Entities.Models
{
    public class TaskItemModel
    {
        private TaskItemModel(Guid id, string name, string description, string author, DateTime startDate, DateTime endDate)
        {
            Id = id;
            Title = name;
            Description = description;
            Author = author;
            StartDate = startDate;
            EndDate = endDate;
        }

        public Guid Id { get; }
        public string Title { get; }
        public string Description { get; }
        public string Author { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }

        /// <summary>
        /// пример статической фабрики.
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="author"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static (TaskItemModel TaskItem, string Error) Create(Guid id, string name, string description, string author, DateTime startDate, DateTime endDate)
        {
            var errors = new List<string>();

            if (endDate < startDate)
                errors.Add("The end date cannot be earlier than the start date");

            if (string.IsNullOrWhiteSpace(name))
                errors.Add("The name cannot be empty");

            if (errors.Any())
                return (null, string.Join("; ", errors));

            var taskItem = new TaskItemModel(id, name, description, author, startDate, endDate);
            return (taskItem, "");
        }
    }
}
