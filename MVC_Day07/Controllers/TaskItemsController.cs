using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core.Models;
using Infrastructure.Data.DbContexts;
using Core.Interfaces;
using Infrastructure.Repositories;

namespace MVC_Day07.Controllers
{
    public class TaskItemsController : Controller
    {
        ITaskRepository _repository;
        public TaskItemsController()
        {
            _repository = new TaskRepository(new TaskDbContext());
        }

        // GET: TaskItems
        public IActionResult Index()
        { 
            var tasks = _repository.GetAllTasks();
            return View(tasks);
        }

        // GET: TaskItems/Details/5
        public IActionResult Details(int id)
        {
            var taskItem = _repository.GetTaskById(id);
            if (taskItem == null)
            {
                return NotFound();
            }

            return View(taskItem);
        }

        // GET: TaskItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TaskItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public IActionResult Create(TaskItem taskItem)
        {
            if (ModelState.IsValid)
            {
               _repository.AddTask(taskItem);
               _repository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(taskItem);
        }

        // GET: TaskItems/Edit/5
        public IActionResult Edit(int id)
        {
            var taskItem = _repository.GetTaskById(id);
            if (taskItem == null)
            {
                return NotFound();
            }
            return View(taskItem);
        }

        // POST: TaskItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,TaskItem taskItem)
        {
            if (id != taskItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _repository.UpdateTask(taskItem);
                _repository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(taskItem);
        }

        // GET: TaskItems/Delete/5
        public IActionResult Delete(int id)
        {
            var taskItem = _repository.GetTaskById(id);
            if (taskItem == null)
            {
                return NotFound();
            }

            return View(taskItem);
        }

        // POST: TaskItems/Delete/5
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var taskItem = _repository.GetTaskById(id);
            if (taskItem != null)
            {
               _repository.DeleteTask(taskItem);
            }

            _repository.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
