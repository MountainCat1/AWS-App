using System.Net.WebSockets;
using Microsoft.AspNetCore.Http;

namespace WebSocketHandlerCore;

public class WebSocketManagerMiddleware
{
    private readonly RequestDelegate _next;
    private WebSocketHandler _webSocketHandler;

    public WebSocketManagerMiddleware(RequestDelegate next,
        WebSocketHandler webSocketHandler)
    {
        _next = next;
        _webSocketHandler = webSocketHandler;
    }

    public async Task Invoke(HttpContext context)
    {
        if (!context.WebSockets.IsWebSocketRequest)
            return;

        var socket = await context.WebSockets.AcceptWebSocketAsync();
        await _webSocketHandler.OnConnected(socket);

        await Receive(socket, async (result, buffer) =>
        {
            if (result.MessageType == WebSocketMessageType.Text)
            {
                await _webSocketHandler.ReceiveAsync(socket, result, buffer);
                return;
            }
            
            if (result.MessageType == WebSocketMessageType.Close)
            {
                await _webSocketHandler.OnDisconnected(socket);
                return;
            }
        });
    }

    private async Task Receive(WebSocket socket, Action<WebSocketReceiveResult, byte[]> handleMessage)
    {
        var buffer = new byte[1024 * 4];

        while (socket.State == WebSocketState.Open)
        {
            var result = await socket.ReceiveAsync(buffer: new ArraySegment<byte>(buffer),
                cancellationToken: CancellationToken.None);

            handleMessage(result, buffer);
        }
    }
}