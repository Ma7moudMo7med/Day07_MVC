using Core.Interfaces;
using Core.Models;
using Infrastructure.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories 
{
    public class TaskRepository : ITaskRepository
    {
        // Implementation of TaskRepository
        TaskDbContext _context;
        public TaskRepository(TaskDbContext context)
        {
            _context = context;
        }
        public void AddTask(TaskItem task)
        {
            _context.Add(task);
        }
        public void UpdateTask(TaskItem task)
        {
            _context.Update(task);
        }
        public void DeleteTask(TaskItem task)
        {
            _context.Remove(task);
        }
        public IEnumerable<TaskItem> GetAllTasks()
        {
            return _context.Tasks.ToList();
        }
        public TaskItem GetTaskById(int id)
        {
            return _context.Tasks.Find(id);
        }
        public void Save()
        {
            _context.SaveChanges();
        }


    }
}
