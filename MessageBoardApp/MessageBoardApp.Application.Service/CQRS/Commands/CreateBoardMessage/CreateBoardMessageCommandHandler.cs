using AutoMapper;
using MediatR;
using MessageBoardApp.Application.Service.Abstractions;
using MessageBoardApp.Application.Service.Dtos;
using MessageBoardApp.Domain.Abstractions;
using MessageBoardApp.Domain.Entities;
using MessageBoardApp.Domain.Events;
using MessageBoardApp.Domain.Repositories;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MessageBoardApp.Application.Service.CQRS.Commands.CreateBoardMessage;

public class CreateBoardMessageCommandHandler : ICommandHandler<CreateBoardMessageCommand>
{
    private IBoardMessageRepository _boardMessageRepository;
    private IMapper _mapper;
    
    public CreateBoardMessageCommandHandler(IBoardMessageRepository boardMessageRepository, IMapper mapper)
    {
        _boardMessageRepository = boardMessageRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(CreateBoardMessageCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<BoardMessageEntity>(request.Dto);
        
        entity.PostTime = DateTime.Now;

        await _boardMessageRepository.CreateAsync(entity);

        entity.AddDomainEvent(new MessageCreatedDomainEvent()
        {
            Entity = entity
        });

        await _boardMessageRepository.SaveChangesAsync();
        
        return Unit.Value;
    }
}