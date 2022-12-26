using System.Collections.Concurrent;
using System.Net.WebSockets;

namespace WebSocketHandlerCore;

public class WebSocketConnectionManager
{
    private static readonly ConcurrentDictionary<string, WebSocket> Sockets = new();

    public WebSocket GetSocketById(string id)
    {
        return Sockets.FirstOrDefault(p => p.Key == id).Value;
    }

    public ConcurrentDictionary<string, WebSocket> GetAll()
    {
        return Sockets;
    }

    public string GetId(WebSocket socket)
    {
        return Sockets.FirstOrDefault(p => p.Value == socket).Key;
    }

    public void AddSocket(WebSocket socket)
    {
        Sockets.TryAdd(CreateConnectionId(), socket);
    }

    public async Task RemoveSocket(string id)
    {
        Sockets.TryRemove(id, out var socket);

        if (socket is null)
            throw new InvalidOperationException($"Socket with id {id} doesnt exist");
            
        await socket.CloseAsync(closeStatus: WebSocketCloseStatus.NormalClosure,
            statusDescription: "Closed by the WebSocketManager",
            cancellationToken: CancellationToken.None);
    }

    private string CreateConnectionId()
    {
        return Guid.NewGuid().ToString();
    }
}
