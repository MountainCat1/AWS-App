using AppApi;
using AppApi.CQRS.Commands.CreateBoardMessage;
using AppApi.Domain.Entities;
using AppApi.Domain.Repositories;
using AppApi.Dtos;
using AutoMapper;
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
    public async Task Test1()
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