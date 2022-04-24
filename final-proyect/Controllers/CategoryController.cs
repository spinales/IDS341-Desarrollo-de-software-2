using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using final_proyect.Models;
using Microsoft.EntityFrameworkCore;

namespace final_proyect.Controllers;

public class CategoryController : Controller
{
    private readonly ILogger<CategoryController> _logger;

    public CategoryController(ILogger<CategoryController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index(string searchString)
    {
        using (var db = new yugabyteContext())
        {
            var categories = db.Categories.ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                categories = categories.Where(x => x.Name!.Contains(searchString)).ToList();
            }

            return View(categories.ToList());
        }   
    }

    public IActionResult Create() {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(
        [Bind("Name")] Category categoria)
    {
        try
        {
            using (var db = new yugabyteContext())
            {
                if (ModelState.IsValid)
                {   
                    db.Add(categoria);
                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                
            }       
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex.Message);
        }

        return View(categoria);
    }

    public IActionResult Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        using (var db = new yugabyteContext()) {
            var cat = db.Categories.Where(x => x.Id == id).FirstOrDefault();

            if (cat == null)
            {
                return NotFound();
            }

            return View(cat);
        }
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        
        using (var db = new yugabyteContext()) {
            var cat = await db.Categories.FindAsync(id);
            if (cat == null)
            {
                return NotFound();
            }
            return View(cat);
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Category category)
    {
        if (id != category.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            using (var db = new yugabyteContext()) {
                db.Update(category);
                await db.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
        return View(category);
    }

    // GET: Movies/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        using (var db = new yugabyteContext()) {
            var category = await db.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }

        return View(category);
        }
    }

    // POST: Movies/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        using (var db = new yugabyteContext()) {
            var category = await db.Categories.FindAsync(id);
            if (category != null)
            {
                db.Categories.Remove(category);
                await db.SaveChangesAsync();    
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
            
        }
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}