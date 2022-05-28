using Microsoft.AspNetCore.Mvc;
using MyRevConnect.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using MyRevConnect.Data.Models;

namespace MyRevConnect.Controllers
{
    [Route("api/clock")]
    [ApiController]
    public class ClockController : ControllerBase
    {
        private readonly Context _context;
        private readonly ILogger<ClockController> _logger;

        public ClockController(ILogger<ClockController> logger, Context context)
        {
            _logger = logger;
            _context = context;
        }

    }
}