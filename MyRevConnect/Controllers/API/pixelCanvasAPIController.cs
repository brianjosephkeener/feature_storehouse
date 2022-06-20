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
        [HttpPost]
        [Route("{ipAddress}")]

        [HttpGet]
        [Route("{ipAddress}")]
        public ActionResult<timedEmail> GetEmailByIp(string ipAddress)
        {
            return _context.timedEmails.FirstOrDefault(x => x.ipAddress == ipAddress);
        }
        // this route is only for the thread to make requests to so the system
        // can check all the emails
        [HttpGet]
        [Route("checkstatus")]
        public void CheckEmails()
        {
            List<timedEmail> timedEmails = _context.timedEmails.Where(x => x.time <= DateTime.Now && x.emailSent == false).OrderByDescending(x => x.time).ToList();
            if(timedEmails.Count > 0)
            {
                for (int i = 0; i < timedEmails.Count; i++)
                {
                    SendEmail(timedEmails[i].emailAddress, timedEmails[i].emailHeader, timedEmails[i].emailBody);
                    timedEmails[i].emailSent = true;
                    timedEmails[i].updatedAt = DateTime.Now;
                    _context.Update(timedEmails[i]);
                }
                _context.SaveChanges();
            }

        }

        [HttpPost]
    public async Task<StatusCodeResult> PostNewEmail(timedEmail timedEmailDTO)
        {
            try
            {
                // check if the time is before or equal to now then send email
                // else, we only add the timedEmailDTO for later
                if (timedEmailDTO.time <= DateTime.Now)
                {
                    SendEmail(timedEmailDTO.emailAddress, timedEmailDTO.emailHeader, timedEmailDTO.emailBody);
                    timedEmailDTO.emailSent = true;
                    _context.Add(timedEmailDTO);
                    _context.SaveChanges();
                    return StatusCode(200);
                }
                timedEmailDTO.emailSent = false;
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
    private void SendEmail(string receiver, string subject, string body)
        {
            SmtpClient Client = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential()
                // set usersecret with key of "emailpassword" and a value of your APP password in the google account Security tab.
                // change username to your gmail account if needed
                {
                    UserName = "brian120496@gmail.com",
                    Password = _config["emailpassword"]
                }
            };
            MailAddress FromEmail = new MailAddress("brian120496@gmail.com", "Feature Storehouse");
            MailAddress ToEmail = new MailAddress(receiver);
            MailMessage Message = new MailMessage()
            {
                From = FromEmail,
                Subject = subject,
                Body = body,
            };
            Message.To.Add(ToEmail);
            try
            {
                Client.Send(Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in sending message to {receiver} with exception {ex.InnerException.Message}");
            }
            
        }
    }
}
