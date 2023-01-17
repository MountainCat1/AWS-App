using System.Linq.Expressions;
using MessageBoardApp.Application.Service.Abstractions;
using MessageBoardApp.Application.Service.Dtos;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace MessageBoardApp.Application.Service.CQRS.Queries.FetchBoardMessages;

public class FetchBoardMessagesQuery : IQuery<IEnumerable<BoardMessageDto>>
{
    public Guid LastMessage { get; set; }
}