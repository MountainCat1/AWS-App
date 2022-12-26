using MessageBoardApp.Application.Domain.Entities;
using MessageBoardApp.Application.Domain.Repositories;
using AutoMapper;
using MessageBoardApp.Application.Service.CQRS.Queries.GetAllBoardMessages;
using MessageBoardApp_Tests.Mockups;
using NSubstitute;

namespace MessageBoardApp_Tests.QueriesTests;

public class QueriesTests
{
    private IMapper _mapper;
    
    [SetUp]
    public void Setup()
    {
        _mapper = MapperMock.CreateMapper();
    }

    [Test]
    public async Task Test_GetAllBoardMessagesQueryHandler()
    {
        // Arrange
        const string message = "Some message";
        var entities = new List<BoardMessageEntity>()
        {
            new() { Text = "Message1" },
            new() { Text = "Message2" }
        };
        
        var repoMock = Substitute.For<IBoardMessageRepository>();
        repoMock.GetAllAsync().Returns(entities);

        var query = new GetAllBoardMessagesQuery();
        var queryHandler = new GetAllBoardMessagesQueryHandler(repoMock, _mapper);
        
        // Act
        var queryResult =  await queryHandler.Handle(query, CancellationToken.None);
        
        // Assert
        await repoMock.Received(1).GetAllAsync();
        
        Assert.That(queryResult.Count == entities.Count, Is.True);
        foreach (var entity in entities)
        {
            Assert.That(queryResult.Any(dto => dto.Text == entity.Text), Is.True);
        }
    }
}