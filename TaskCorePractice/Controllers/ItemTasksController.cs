using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskCorePractice.Models;

namespace TaskCorePractice.Controllers
{
    public class ItemTasksController : Controller
    {
        private readonly TaskCorePracticDBContext _context;

        public ItemTasksController(TaskCorePracticDBContext context)
        {
            _context = context;
        }

        // GET: ItemTasks
        public async Task<IActionResult> Index()
        {
            var taskCorePracticDBContext = _context.ItemTask.Include(i => i.UserTask);
            return View(await taskCorePracticDBContext.ToListAsync());
        }

        // GET: ItemTasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemTask = await _context.ItemTask
                .Include(i => i.UserTask)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (itemTask == null)
            {
                return NotFound();
            }

            return View(itemTask);
        }

        // GET: ItemTasks/Create
        public IActionResult Create()
        {
            ViewData["UserTaskId"] = new SelectList(_context.UserTask, "Id", "Desc");
            return View();
        }

        // POST: ItemTasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserTaskId,Name")] ItemTask itemTask)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemTask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserTaskId"] = new SelectList(_context.UserTask, "Id", "Desc", itemTask.UserTaskId);
            return View(itemTask);
        }

        // GET: ItemTasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemTask = await _context.ItemTask.FindAsync(id);
            if (itemTask == null)
            {
                return NotFound();
            }
            ViewData["UserTaskId"] = new SelectList(_context.UserTask, "Id", "Desc", itemTask.UserTaskId);
            return View(itemTask);
        }

        // POST: ItemTasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserTaskId,Name")] ItemTask itemTask)
        {
            if (id != itemTask.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemTask);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemTaskExists(itemTask.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserTaskId"] = new SelectList(_context.UserTask, "Id", "Desc", itemTask.UserTaskId);
            return View(itemTask);
        }

        // GET: ItemTasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemTask = await _context.ItemTask
                .Include(i => i.UserTask)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (itemTask == null)
            {
                return NotFound();
            }

            return View(itemTask);
        }

        // POST: ItemTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itemTask = await _context.ItemTask.FindAsync(id);
            _context.ItemTask.Remove(itemTask);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemTaskExists(int id)
        {
            return _context.ItemTask.Any(e => e.Id == id);
        }
    }
}
