using AutoMapper;
using MessageBoardApp.Application.Service.Abstractions;
using MessageBoardApp.Application.Service.Dtos;
using MessageBoardApp.Domain.Repositories;

namespace MessageBoardApp.Application.Service.CQRS.Queries.FetchBoardMessages;

public class FetchBoardMessagesQueryHandler : IQueryHandler<FetchBoardMessagesQuery, IEnumerable<BoardMessageDto>>
{
    private readonly IBoardMessageRepository _boardMessageRepository;
    private readonly IMapper _mapper;

    public FetchBoardMessagesQueryHandler(IBoardMessageRepository boardMessageRepository, IMapper mapper)
    {
        _boardMessageRepository = boardMessageRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<BoardMessageDto>> Handle(FetchBoardMessagesQuery query, CancellationToken cancellationToken)
    {
        // TODO here
        var entities = await _boardMessageRepository
            .GetAsync(x => true, x => x.OrderBy(y => y.PostTime));

        var dtos = _mapper.Map<IEnumerable<BoardMessageDto>>(entities);
        
        return dtos;
    }
}