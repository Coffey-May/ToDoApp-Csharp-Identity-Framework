using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDoAppIdentityFW.Data;
using ToDoAppIdentityFW.Models;
using ToDoAppIdentityFW.Models.ViewModels;

namespace ToDoAppIdentityFW.Controllers
{
    [Authorize]
    public class ToDoItemsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ToDoItemsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: TodoItems
        public async Task<ActionResult> Index(string status)
        {
            var user = await GetCurrentUserAsync();
            List<ToDoItem> items = new List<ToDoItem>();
            if (status == "finished")
            {
                items = await _context.ToDoItem
                       .Include(s => s.ToDoStatus)
                       .Where(s => s.ApplicationUserId == user.Id)
                       .Where(s => s.ToDoStatusId == 3)
                       .ToListAsync();
            }
            else if (status == "progress")
            {
                items = await _context.ToDoItem
                    .Include(s => s.ToDoStatus)
                    .Where(s => s.ApplicationUserId == user.Id)
                    .Where(s => s.ToDoStatusId == 2)
                    .ToListAsync();
            }
            else if (status == "notStarted")
            {
                items = await _context.ToDoItem
                    .Include(s => s.ToDoStatus)
                    .Where(s => s.ApplicationUserId == user.Id)
                    .Where(s => s.ToDoStatusId == 1)
                    .ToListAsync();
            }
            else
            {
                items = await _context.ToDoItem
                    .Include(s => s.ToDoStatus)
                    .Where(s => s.ApplicationUserId == user.Id)
                    .ToListAsync();
            }

            return View(items);
        }

        // GET: ToDoItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toDoItem = await _context.ToDoItem
                .Include(t => t.ApplicationUser)
                .Include(t => t.ToDoStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toDoItem == null)
            {
                return NotFound();
            }

            return View(toDoItem);
        }


        // GET: TodoItems/Create
        public async Task<ActionResult> Create()
        {
            var allStatuses = await _context.ToDoStatus
               .Select(d => new SelectListItem() { Text = d.Title, Value = d.Id.ToString() })
               .ToListAsync();

            var viewModel = new TodoItemViewModel();
            viewModel.ToDoStatusOptions = allStatuses;
            return View(viewModel);
        }

        // POST: TodoItems/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TodoItemViewModel viewItem)
        {
            try
            {
                var user = await GetCurrentUserAsync();
                var item = new ToDoItem()
                {
                    Title = viewItem.Title,
                    ToDoStatusId = viewItem.TodoStatusId
                };
                item.ApplicationUserId = user.Id;

                _context.ToDoItem.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // GET: TodoItems/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var allStatuses = await _context.ToDoStatus
              .Select(d => new SelectListItem() { Text = d.Title, Value = d.Id.ToString() })
              .ToListAsync();
            var item = await _context.ToDoItem.FirstOrDefaultAsync(i => i.Id == id);
            var loggedInUser = await GetCurrentUserAsync();

            if (item.ApplicationUserId != loggedInUser.Id)
            {
                return NotFound();
            }
            var viewModel = new TodoItemViewModel()
            {
                Id = item.Id,
                Title = item.Title,
                TodoStatusId = item.ToDoStatusId,
                ToDoStatusOptions = allStatuses
            };

            return View(viewModel);
        }

        // POST: TodoItems/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, TodoItemViewModel viewModel)
        {
            try
            {
                var user = await GetCurrentUserAsync();
                var item = new ToDoItem()
                {
                    Id = viewModel.Id,
                    Title = viewModel.Title,
                    ToDoStatusId = viewModel.TodoStatusId,
                    ApplicationUserId = user.Id
                };

                _context.ToDoItem.Update(item);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TodoItems/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var item = await _context.ToDoItem.Include(s => s.ToDoStatus).FirstOrDefaultAsync(i => i.Id == id);

            return View(item);
        }

        // POST: TodoItems/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, ToDoItem item)
        {
            try
            {
                _context.ToDoItem.Remove(item);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}