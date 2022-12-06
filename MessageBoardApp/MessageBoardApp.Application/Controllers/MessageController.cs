using AppApi.CQRS.Commands.CreateBoardMessage;
using AppApi.CQRS.Queries.GetAllBoardMessages;
using AppApi.Dtos;
using MediatR;
using MessageBoardApp.Infrastructure.Generics;
using Microsoft.AspNetCore.Mvc;

namespace AppApi.Controllers;

[ApiController]
[Route("board")]
public class MessageController : Controller
{
    private IMediator _mediator;

    public MessageController(IMediator mediator)
    {
        _mediator = mediator;
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
}