using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using Moodle_Clone.Domain.Models;
using Moodle_Clone.Infraestructure.Context;
using MailKit.Net.Smtp;

namespace Moodle_Clone.Infraestructure.Services
{
    public class EmailService
    {
        private readonly IConfiguration _config;

        public EmailService(DatabaseContext context, IConfiguration configuration) 
        {
            _config = configuration;
        }

        public async Task SendAssignmentDeadlineEmail(Users student, Assignments assignment)
        {
            DateTime currentDate = DateTime.Now;
            if(assignment.LimitDate.Date == currentDate.AddDays(1).Date)
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(_config["EmailUsername"]));
                email.To.Add(MailboxAddress.Parse(student.Email));
                email.Subject = $"Assignment Deadline Reminder: {assignment.AssignmentsName}";

                var body = $"Hi {student.Name},<br/><br/>";
                body += $"This is a friendly reminder that the deadline for the assignment \"{assignment.AssignmentsName}\" is approaching.<br/>";
                body += $"The deadline is on {assignment.LimitDate.ToString("dd MMMM yyyy HH:mm")}.<br/><br/>";
                body += $"Please make sure to submit your work before the deadline to avoid any late penalties.<br/><br/>";
                body += "Best regards,<br/>";
                body += "The Moodle-Clone Team";

                email.Body = new TextPart(TextFormat.Html) { Text = body };

                using var smtp = new SmtpClient();
                smtp.Connect(_config["EmailHost"], 587, SecureSocketOptions.StartTls);
                smtp.Authenticate(_config["EmailUsername"], _config["EmailPassword"]);

                await smtp.SendAsync(email);

                await smtp.DisconnectAsync(true);
            }
        }
    }
}
