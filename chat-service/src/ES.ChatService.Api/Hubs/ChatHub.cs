using System.Text.Json;
using ES.ChatService.Domain.Models;
using FluentValidation;
using Microsoft.AspNetCore.SignalR;

namespace ES.ChatService.Api.Hubs;

public class ChatHub : Hub
{
    private readonly ILogger<ChatHub> _logger;
    private readonly IValidator<Message> _validator;

    public ChatHub(
        ILogger<ChatHub> logger,
        IValidator<Message> validator)
    {
        _logger = logger;
        _validator = validator;
    }

    public override Task OnConnectedAsync()
    {
        _logger.LogInformation("Connection opened := {ConnectionId}", Context.ConnectionId);
        Clients.Client(Context.ConnectionId).SendAsync("ReceivedConnectionId", Context.ConnectionId);
        return base.OnConnectedAsync();
    }

    public async Task SendMessageAsync(string message)
    {
        var messageModel = JsonSerializer.Deserialize<Message>(message);
        if (messageModel is null)
            throw new NullReferenceException($"Message can not be null, connectionId := {Context.ConnectionId}");

        var result = _validator.Validate(messageModel);
        if (!result.IsValid)
        {
            result.Errors.ForEach(failure =>
            {
                _logger.LogInformation(failure.ErrorMessage);
            });

            throw new ValidationException("Failed message model validation");
        }

        await Clients.Client(messageModel.To).SendAsync("ReceiveMessage", message);
    }
}