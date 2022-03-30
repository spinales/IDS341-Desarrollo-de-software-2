using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using crudweb.Models;

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
}
