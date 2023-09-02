using Kendo.Mvc.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Telerik.Examples.Mvc.Models;

namespace Telerik.Examples.Mvc.Controllers.Grid;

public class TasksController : Controller
{
    private readonly GeneralDbContext _context; 

    public TasksController(GeneralDbContext context)
    {
        _context = context;
    }

    public ActionResult List()
    {
        IEnumerable<Telerik.Examples.Mvc.Models.Task> taks;

        taks = _context.Tasks
                   .Select(c => new Telerik.Examples.Mvc.Models.Task
                   {
                       TaskID = c.TaskID,
                       Title = c.Title
                   })
                   .OrderBy(e => e.Title).ToList();

        return Json(taks);
    }

}


 


  