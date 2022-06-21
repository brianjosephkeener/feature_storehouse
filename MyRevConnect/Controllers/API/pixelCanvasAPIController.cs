using Microsoft.AspNetCore.Mvc;
using MyRevConnect.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using MyRevConnect.Data.Models;
using System.Net.Mail;
using System.Net;
using System.Timers;


namespace MyRevConnect.API
{
    [Route("api/pixelcanvas")]
    [ApiController]
    public class pixelCanvasAPIController : ControllerBase
    {
        private readonly IConfiguration _config; 
        private readonly Context _context;
        private readonly ILogger<pixelCanvasAPIController> _logger;

        public pixelCanvasAPIController(ILogger<pixelCanvasAPIController> logger, Context context, IConfiguration config)
        {
            _logger = logger;
            _context = context;
            _config = config;
        }

        [HttpGet]
        public ActionResult<List<Pixel>> GetAllPixels()
        {
            return _context.pixels.ToList();
        }

   
    }
}
