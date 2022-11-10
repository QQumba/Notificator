namespace Notificator.DataTransfer;

public class Message
{
    public int Id { get; set; }

    public string Payload { get; set; } = null!;

    public string Sender { get; set; } = null!;
}