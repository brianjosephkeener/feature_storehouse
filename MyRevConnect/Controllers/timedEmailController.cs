using Microsoft.AspNetCore.Mvc;
using MyRevConnect.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http.Features;
using MyRevConnect.Data.Models;

namespace MyRevConnect.Controllers
{
    public class timedEmailController : Controller
    {
        private readonly ILogger<timedEmailController> _logger;
        public timedEmailController(ILogger<timedEmailController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        [Route("timedemail")]
        public IActionResult timedEmailPage()
        {
            // ::1 is the actual IP. It is an ipv6 loopback address (i.e. localhost).
            // if using ipv4 it would be 127.0.0.1
            var remoteIpAddress = Request.HttpContext.Connection.RemoteIpAddress;
            ViewBag.RemoteIpAddress = remoteIpAddress;
            return View("~/Views/Features/Timed_Email.cshtml");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
