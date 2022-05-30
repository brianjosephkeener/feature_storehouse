using Microsoft.AspNetCore.Mvc;
using MyRevConnect.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using MyRevConnect.Data.Models;
using System.Net.Mail;
using System.Net;

namespace MyRevConnect.API
{
    [Route("api/timedemail")]
    [ApiController]
    public class timedEmailAPIController : ControllerBase
    {
        private readonly IConfiguration _config; 
        private readonly Context _context;
        private readonly ILogger<timedEmailAPIController> _logger;

        public timedEmailAPIController(ILogger<timedEmailAPIController> logger, Context context, IConfiguration config)
        {
            _logger = logger;
            _context = context;
            _config = config;
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
                SendEmail(timedEmailDTO.emailAddress, timedEmailDTO.emailHeader, timedEmailDTO.emailBody);
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
            MailAddress FromEmail = new MailAddress("brian120496@gmail.com", "Timed Email");
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
