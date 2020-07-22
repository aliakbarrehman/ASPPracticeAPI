using ASPPracticeAPI.DbContexts;
using ASPPracticeAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ASPPracticeAPI.Services
{
    public class TaskRepository : IDisposable
    {
        private MySqlDbContext _dbContext { get; set; }

        public TaskRepository(MySqlDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddTask(Task task)
        {
            _dbContext.Tasks.Add(task);
            _dbContext.SaveChanges();
        }
        public IEnumerable<Task> GetTasks(int userId)
        {
            return _dbContext.Tasks.Where(x => x.UserId == userId).ToList<Task>();
        }
        public Task GetTask(int userId, int taskId)
        {
            return _dbContext.Tasks.Where(x => x.UserId == userId && x.Id == taskId).FirstOrDefault();
        }
        public void UpdateTask(int taskId, Task task)
        {

        }
        public void DeleteTask(Task task)
        {
            _dbContext.Tasks.Remove(task);
        }
        public void Dispose()
        {
            // Dispose here
        }
    }
}
