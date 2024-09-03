using HrApp.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Serilog;
using System;

namespace HrApp.Controllers.Odata
{
    public class JobsController : ControllerBase
    {

        private readonly HrDBContext _context;

        public JobsController(HrDBContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IActionResult Get()
        {
            Log.Information("Index sayfasına erişildi.");
            return Ok(_context.Job);
        }

        [EnableQuery]
        public IActionResult Get(int key)
        {
            var product = _context.Job.FirstOrDefault(p => p.JobId == key);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
