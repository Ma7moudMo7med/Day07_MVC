using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Data.ConfigurationClasses
{
    internal class TaskConfiguration : IEntityTypeConfiguration<TaskItem>
    {
        public void Configure(EntityTypeBuilder<TaskItem> builder)
        {
           builder.HasKey(t => t.Id);
              builder.Property(t => t.Title).IsRequired().HasMaxLength(100);
                builder.Property(t => t.Description).HasMaxLength(200);
                builder.Property(t => t.IsCompleted).HasDefaultValue(false);
                builder.Property(t => t.CreatedAt).HasDefaultValueSql("GETDATE()");
        }
    }
}
