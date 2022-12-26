using AutoMapper;
using MessageBoard.Domain.Entities;
using MessageBoardApp.Application.Service.Dtos;

namespace MessageBoard;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateBoardMessageDto, BoardMessageEntity>();

        CreateMap<BoardMessageEntity, BoardMessageDto>();
    }
}