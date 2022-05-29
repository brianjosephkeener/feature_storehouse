using Microsoft.AspNetCore.Mvc;
using MyRevConnect.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using MyRevConnect.Data.Models;

namespace MyRevConnect.API
{
    [Route("api/timedemail")]
    [ApiController]
    public class timedEmailAPIController : ControllerBase
    {
        private readonly Context _context;
        private readonly ILogger<timedEmailAPIController> _logger;

        public timedEmailAPIController(ILogger<timedEmailAPIController> logger, Context context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<timedEmail>> GetAllEmails()
        {
            return _context.timedEmails.ToList();
        }
        [HttpGet]
        [Route("{ipAddress}")]
        public ActionResult<timedEmail> GetEmailByIp(string ipAddress)
        {
            return _context.timedEmails.FirstOrDefault(x => x.ipAddress == ipAddress);
        }


        [HttpPost]
    public async Task<StatusCodeResult> PostNewEmail(timedEmail timedEmailDTO)
        {
            try
            {
                _context.Add(timedEmailDTO);
                _context.SaveChanges();
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in posting email for id: {timedEmailDTO.Id} with ip: {timedEmailDTO.ipAddress}");
                return StatusCode(500);
            }
        }
    }
}
