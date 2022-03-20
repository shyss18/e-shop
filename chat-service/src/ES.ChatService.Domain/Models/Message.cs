namespace ES.ChatService.Domain.Models;

public class Message
{
    public string Text { get; set; }

    public string From { get; set; }

    public string To { get; set; }
}