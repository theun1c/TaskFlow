using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Domain.Entities.Models;
using TaskFlow.Infrastructure.Entities.Models;

namespace TaskFlow.Infrastructure.Configurations
{
    public class TaskItemConfiguration : IEntityTypeConfiguration<TaskItemModel>
    {
        public void Configure(EntityTypeBuilder<TaskItemModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(255);
            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
