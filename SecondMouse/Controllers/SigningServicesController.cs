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
    public class SigningServicesController : ControllerBase
    {
        private readonly SigningServicesContext _context;

        public SigningServicesController(SigningServicesContext context)
        {
            _context = context;
        }

        //api/SigningServices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SigningServices>>> GetSigningServices()
        {
            return await _context.SigningServices.ToListAsync();
        }

        [HttpGet("{state}")]
        public async Task<ActionResult<IEnumerable<SigningServices>>> GetSigningServiceByState(string state)
        {
            var signingService = await _context.SigningServices.Where(ss => ss.state == state).ToListAsync();

            if (signingService != null)
            {
                return signingService;
            }
            return NotFound();
        }
    }
}