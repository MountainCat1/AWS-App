using System.Net.WebSockets;
using System.Text;
using MediatR;
using MessageBoardApp.Application.Service.CQRS.Commands.CreateBoardMessage;
using MessageBoardApp.Application.Service.CQRS.Queries.GetAllBoardMessages;
using MessageBoardApp.Application.Service.Dtos;
using MessageBoardApp.Application.WebSockets;
using Microsoft.AspNetCore.Mvc;

namespace MessageBoardApp.Application.Controllers;

[ApiController]
[Route("board")]
public class MessageController : Controller
{
    private readonly IMediator _mediator;
    private readonly ILogger<MessageController> _logger;
    private readonly MessageWebSocketHandler _messageWebSocketHandler;

    public MessageController(
        IMediator mediator,
        ILogger<MessageController> logger,
        MessageWebSocketHandler messageWebSocketHandler)
    {
        _mediator = mediator;
        _logger = logger;
        _messageWebSocketHandler = messageWebSocketHandler;
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


    [HttpGet("update")]
    public async Task ReceiveMessageSocket()
    {
        await _messageWebSocketHandler.SendMessageToAllAsync("SEX");
    }
}