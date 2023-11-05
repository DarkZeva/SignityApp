using Microsoft.EntityFrameworkCore;

namespace SignityQuest.Models
{
    public class TasksDBContext:DbContext
    {
        public TasksDBContext(DbContextOptions<TasksDBContext> options):base(options) 
        {
        }

        public DbSet<DBPreviousTasks> DBPreviousTasks { get; set; }
    }
}
