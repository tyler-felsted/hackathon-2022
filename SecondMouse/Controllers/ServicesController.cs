using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecondMouse.Models;

namespace SecondMouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : Controller
    {
        private readonly ServicesContext _context;

        public ServicesController(ServicesContext context)
        {
            _context = context;
        }

        [Route("ServicesList")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Services>>> ServicesList()
        {
            var result = await _context.Services.ToListAsync();

            return View(result);
        }

        [Route("FileServiceCheck")]
        [HttpPost]
        public async Task<ActionResult<FileServiceCheck>> PostFileService(File file)
        {
            var service = await _context.Services.SingleOrDefaultAsync(s => s.state == file.state && s.county == file.county);
            var signingService = await _context.SigningServices.Where(ss => ss.state == file.state).ToListAsync();

            if (service == null)
            {
                return NotFound($"No services have been found for {file.county}, {file.state}");
            }

            FileServiceCheck fileServiceCheckResults = new FileServiceCheck();
            fileServiceCheckResults.file = file;
            fileServiceCheckResults.service = service;
            fileServiceCheckResults.signingServices = signingService;

            return fileServiceCheckResults;
        }
    }
}