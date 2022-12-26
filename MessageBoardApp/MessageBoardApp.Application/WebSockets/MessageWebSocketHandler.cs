using System.Net.WebSockets;
using WebSocketHandlerCore;

namespace AppApi.WebSockets;

public class MessageWebSocketHandler : WebSocketHandler
{
    private ILogger<MessageWebSocketHandler> _logger;

    public MessageWebSocketHandler(WebSocketConnectionManager webSocketConnectionManager, ILogger<MessageWebSocketHandler> logger) : base(webSocketConnectionManager)
    {
        _logger = logger;
    }

    public override async Task ReceiveAsync(WebSocket socket, WebSocketReceiveResult result, byte[] buffer)
    {
        _logger.LogInformation("Got a message {message}", result.MessageType);
    }
}