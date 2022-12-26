using MessageBoard.Domain.Entities;
using MessageBoard.Domain.Repositories;
using AutoMapper;
using MediatR;
using MessageBoardApp.Application.Service.Abstractions;

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

        await _boardMessageRepository.SaveChangesAsync();
        
        return Unit.Value;
    }
}