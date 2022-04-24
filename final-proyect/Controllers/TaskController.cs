using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using final_proyect.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace final_proyect.Controllers;

public class TaskController : Controller
{
    private readonly ILogger<CategoryController> _logger;

    public TaskController(ILogger<CategoryController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index(string searchString)
    {
        using (var db = new yugabyteContext())
        {
            // var tasks = db.Tasks.Join(db.Categories,
            //     task => task.CategoryId, // task
            //     cat => cat.Id, // category
                
            //     (task, cat) => new {Task = task, Category = cat}).ToList();
            var tasks = db.Tasks.Where(x => x.Finished == false).Include(c => c.Category).ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                tasks = tasks.Where(x => x.Name!.Contains(searchString)).ToList();
            }

            return View(tasks.ToList());
        }   
    }

    public IActionResult Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        using (var db = new yugabyteContext()) {
            var task = db.Tasks.Where(x => x.Id == id).Include(c => c.Category).FirstOrDefault();

            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }
    }

    // GET: Task/Create
    public IActionResult Create()
    {
        using (var db = new yugabyteContext()) {
            var categories = db.Categories.ToList();
            ViewData["Categorias"] = new SelectList(categories,"Id","Name");
            return View();
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(
        [Bind("CategoryId,Name,Description,Finished")] Models.Task tarea)
    {
        try
        {
            using (var db = new yugabyteContext()) {
                _logger.LogInformation(tarea.Finished.ToString());
                tarea.Finished = false;
                db.Add(tarea);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex.Message);
        }

        return View(tarea);
    }


    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        using (var db = new yugabyteContext()) {
            var categories = db.Categories.ToList();
            ViewData["Categorias"] = new SelectList(categories,"Id","Name");
            var task = await db.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,CategoryId,Name,Description,Finished")] Models.Task task)
    {
        if (id != task.Id)
        {
            return NotFound();
        }
        
        using (var db = new yugabyteContext()) {
            db.Update(task);
            await db.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
        
        //return View(task);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        using (var db = new yugabyteContext()) {
            var task = await db.Tasks.Include(c => c.Category).FirstOrDefaultAsync(x => x.Id == id);
            if (task == null)
            {
                return NotFound();
            }

        return View(task);
        }
    }

    // POST: Movies/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        using (var db = new yugabyteContext()) {
            var task = await db.Tasks.FindAsync(id);
            if (task != null)
            {
                task.Finished = true;
                db.Tasks.Update(task);
                await db.SaveChangesAsync();   
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
    }

    public IActionResult Completed(string searchString)
    {
        using (var db = new yugabyteContext())
        {
            var tasks = db.Tasks.Where(x => x.Finished == true).Include(c => c.Category).ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                tasks = tasks.Where(x => x.Name!.Contains(searchString)).ToList();
            }

            return View(tasks.ToList());
        }   
    }   

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}