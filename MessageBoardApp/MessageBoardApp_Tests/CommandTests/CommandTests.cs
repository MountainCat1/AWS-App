using MessageBoardApp.Application.Domain.Entities;
using MessageBoardApp.Application.Domain.Repositories;
using AutoMapper;
using MessageBoardApp.Application.Service.CQRS.Commands.CreateBoardMessage;
using MessageBoardApp.Application.Service.Dtos;
using MessageBoardApp_Tests.Mockups;
using NSubstitute;

namespace MessageBoardApp_Tests.CommandTests;

public class CommandTests
{
    private IMapper _mapper;
    
    [SetUp]
    public void Setup()
    {
        _mapper = MapperMock.CreateMapper();
    }

    [Test]
    public async Task Test_CreateBoardMessageCommandHandler()
    {
        // Arrange
        const string message = "Some message";
        
        var repoMock = Substitute.For<IBoardMessageRepository>();
        var createDto = new CreateBoardMessageDto(message);
        
        var command = new CreateBoardMessageCommand(createDto);
        var commandHandler = new CreateBoardMessageCommandHandler(repoMock, _mapper);
        
        // Act
        await commandHandler.Handle(command, CancellationToken.None);
        
        // Assert
        await repoMock.Received(1).CreateAsync(Arg.Is<BoardMessageEntity>(entity => entity.Text == message));
    }
}