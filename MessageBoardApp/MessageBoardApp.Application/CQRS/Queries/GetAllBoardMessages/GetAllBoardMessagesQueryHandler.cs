using AppApi.Abstractions;
using AppApi.Domain.Repositories;
using AppApi.Dtos;
using AutoMapper;
using MessageBoardApp.Infrastructure.Repositories;

namespace AppApi.CQRS.Queries.GetAllBoardMessages;

public class GetAllBoardMessagesQueryHandler : IQueryHandler<GetAllBoardMessagesQuery, ICollection<BoardMessageDto>>
{
    private IBoardMessageRepository _boardMessageRepository;
    private IMapper _mapper;

    public GetAllBoardMessagesQueryHandler(IBoardMessageRepository boardMessageRepository, IMapper mapper)
    {
        _boardMessageRepository = boardMessageRepository;
        _mapper = mapper;
    }

    public async Task<ICollection<BoardMessageDto>> Handle(GetAllBoardMessagesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _boardMessageRepository.GetAllAsync();

        var dtos = _mapper.Map<ICollection<BoardMessageDto>>(entities);

        return dtos;
    }
}