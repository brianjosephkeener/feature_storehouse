using Microsoft.AspNetCore.Mvc;
using MyRevConnect.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http.Features;
using MyRevConnect.Data.Models;

namespace MyRevConnect.Controllers
{
    public class pixelCanvasController : Controller
    {
        private readonly ILogger<pixelCanvasController> _logger;
        private readonly Context _context;
        public pixelCanvasController(ILogger<pixelCanvasController> logger, Context context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet]
        [Route("pixelcanvas")]
        public async Task<IActionResult> pixelcanvasPage()
        {
            ViewBag.Pixels = _context.pixels.ToList();
            return View("~/Views/Features/Pixel_Canvas.cshtml");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
