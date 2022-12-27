using System.Net;
using System.Net.Mail;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notificator.Data.Entities;
using Notificator.Data.Entities.Enums;
using Notificator.Data.Events;

namespace Notificator.Data.Services;

public class EmailPublishHandler : IPublishHandler
{
    private readonly NotificatorDbContext _context;

    public EmailPublishHandler(NotificatorDbContext context)
    {
        _context = context;
    }

    public async Task HandlePublish(Message message)
    {
        var consumers = await _context.Consumers
            .Where(x => x.TopicId == message.TopicId && x.ConsumerType == ConsumerType.Email)
            .ToListAsync();

        foreach (var consumer in consumers)
        {
            var email = consumer.Address;
            SendEmail(email, message.Payload);
        }
    }

    private void SendEmail(string email, string payload)
    {
        try
        {
            var message = new MailMessage();
            var smtp = new SmtpClient();
            message.From = new MailAddress("mykyta.knysh@nure.ua");
            message.To.Add(new MailAddress(email));
            message.Subject = "Test";
            message.IsBodyHtml = false; //to not make message body as html  
            message.Body = payload;
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com"; //for gmail host  
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("mykyta.knysh@nure.ua", "AYp4Wro5");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(message);
        }
        catch (Exception)
        {
            // ignored
        }
    }
}