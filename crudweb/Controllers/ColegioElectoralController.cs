using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using crudweb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace crudweb.Controllers;

public class ColegioElectoralController : Controller
{
    private readonly ILogger<ColegioElectoralController> _logger;
    private readonly DSFEBABR2022Context _context;

    public ColegioElectoralController(ILogger<ColegioElectoralController> logger)
    {
        _logger = logger;
        _context = new DSFEBABR2022Context();
    }

    public IActionResult Index()
    {
        return View(_context.ColegioElectorals.ToList());
    }

    // GET: ColegioElectoral/Create
    public IActionResult Create()
    {
        var Municipios = _context.Municipios.ToList();
        ViewData["Municipios"] = new SelectList(Municipios,"Id","Nombre");
        var Sectors = _context.Sectors.ToList();
        ViewData["Sectors"] = new SelectList(Sectors,"Id","Nombre");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(
        [Bind("Codigo,Nombre,Descripcion,Direccion,Telefono,MunicipioId,SectorId,Estado")] ColegioElectoral colegio)
    {
        try
        {
            if (ModelState.IsValid)
            {   
                colegio.FechaCreacion = DateTime.Now;
                _context.Add(colegio);
                _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
        }
        catch (DbUpdateException ex)
        {   
            ModelState.AddModelError("", "Unable to save changes. " +
            "Try again, and if the problem persists " +
            "Contact me :)");
        }

        return View(colegio);
    }

    public IActionResult Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        // var colegio = _context.ColegioElectorals.Where(x => x.Id == id).FirstOrDefault();

        var student = _context.ColegioElectorals.Where(x => x.Id == id).FirstOrDefault();
        // .Include(x => x.municipio)
        //     .ThenInclude(e => e.Course)
        // .AsNoTracking()
        // .FirstOrDefaultAsync(m => m.ID == id);

        if (student == null)
        {
            return NotFound();
        }

        return View(student);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View("Error!");
    }

    public IActionResult Edit(int? id)
    {
        var Municipios = _context.Municipios.ToList();
        ViewData["Municipios"] = new SelectList(Municipios,"Id","Nombre");
        var Sectors = _context.Sectors.ToList();
        ViewData["Sectors"] = new SelectList(Sectors,"Id","Nombre");

        if (id == null)
        {
            return NotFound();
        }

        var colegio = _context.ColegioElectorals.Find(id);
        if (colegio == null)
        {
            return NotFound();
        }

        return View(colegio);
    }

    [HttpPost, ActionName("Edit")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditPost(int? id, 
    [Bind("Nombre,Descripcion,Direccion,Telefono,MunicipioId,SectorId")] ColegioElectoral colegio)
    {
        if (id == colegio.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(colegio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException ex)
            {
                //Log the error (uncomment ex variable name and write a log.)
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists, " +
                    "Contact Me :).");
            }
        }
        return View(colegio);
    }
}
