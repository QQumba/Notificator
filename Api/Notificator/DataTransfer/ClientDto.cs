namespace Notificator.DataTransfer;

public class ClientDto
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;
}

public class ClientCreateDto
{
    public string Name { get; set; } = null!;
}