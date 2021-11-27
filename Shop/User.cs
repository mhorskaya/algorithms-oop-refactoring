using System.Net.Mail;

namespace Shop
{
    public class User
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public void Inform(IDomainEvent domainEvent)
        {
            if (IsSubscribedFor(domainEvent))
                new SmtpClient().Send(new MailMessage(from: "Web Shop", to: Email) { Subject = domainEvent.GetEventMessage() });
        }

        public void Subscribe(IDomainEvent domainEvent)
        {
            // Subscribe user to event.
        }

        public bool IsSubscribedFor(IDomainEvent domainEvent)
        {
            // Return true if user is subscribed to domain event.
            return true;
        }
    }
}