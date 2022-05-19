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
    public class ServicesController : ControllerBase
    {
        private readonly ServicesContext _context;

        public ServicesController(ServicesContext context)
        {
            _context = context;
        }

        //api/Services
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Services>>> GetServices()
        {
            return await _context.Services.ToListAsync();
        }

        [HttpGet("{state}/{county}")]
        public async Task<ActionResult<Services>> GetFileServices(string state, string county)
        {
            var service = await _context.Services.SingleOrDefaultAsync(s => s.state == state && s.county == county);

            if (service == null)
            {
                return NotFound();
            }

            return service;
        }
    }
}