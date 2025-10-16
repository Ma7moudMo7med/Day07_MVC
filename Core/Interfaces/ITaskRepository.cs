using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ITaskRepository
    {
        // Definition of ITaskRepository
       public void AddTask(TaskItem task);
       public void UpdateTask(TaskItem task);
       public void DeleteTask(TaskItem task);
        public IEnumerable<TaskItem> GetAllTasks();
        public TaskItem GetTaskById(int id);
        public void Save();

    }
}
