using System.Net.WebSockets;
using System.Text;
using MediatR;
using MessageBoardApp.Application.Service.CQRS.Commands.CreateBoardMessage;
using MessageBoardApp.Application.Service.CQRS.Queries.GetAllBoardMessages;
using MessageBoardApp.Application.Service.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace AppApi.Controllers;

[ApiController]
[Route("board")]
public class MessageController : Controller
{
    private IMediator _mediator;
    private ILogger<MessageController> _logger;

    public MessageController(IMediator mediator, ILogger<MessageController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpPost("post")]
    public async Task<IActionResult> CreateMessage([FromBody] CreateBoardMessageDto dto)
    {
        var command = new CreateBoardMessageCommand(dto);

        await _mediator.Send(command);

        return Ok();
    }


    [HttpGet("all")]
    public async Task<IActionResult> GetAllMessages()
    {
        var query = new GetAllBoardMessagesQuery();

        var queryResult = await _mediator.Send(query);

        return Ok(queryResult);
    }


    [HttpGet("socket")]
    public async Task ReceiveMessageSocket()
    {
        if (!HttpContext.WebSockets.IsWebSocketRequest)
        {
            Response.StatusCode = StatusCodes.Status400BadRequest;
            return;
            // return BadRequest("Request was not a Web Socket Request");
        }

        using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
        await Echo(webSocket);
        // return Ok();
    }

    private async Task Echo(WebSocket webSocket)
    {
        var buffer = new byte[1024 * 4];
        
        WebSocketReceiveResult receiveResult;
        do
        {
            // receiveResult = await webSocket.ReceiveAsync(
            //     new ArraySegment<byte>(buffer), CancellationToken.None);
            //
            // var arraySegment = new ArraySegment<byte>(buffer, 0, receiveResult.Count);

            await Task.Delay(3000);

            var input = "I WANT SEX";
            var bytes = Encoding.UTF8.GetBytes(input);
            var arraySegment = new ArraySegment<byte>(bytes);
            
            await webSocket.SendAsync(
                bytes,
                WebSocketMessageType.Text,
                true,
                CancellationToken.None);

            var messageString = System.Text.Encoding.UTF8.GetString(arraySegment);
            _logger.LogInformation("Got a message \"{0}\"", messageString);
            //
        } while (webSocket.State == WebSocketState.Open);

        await webSocket.CloseAsync(
            WebSocketCloseStatus.Empty,
            null,
            CancellationToken.None);
    }
}