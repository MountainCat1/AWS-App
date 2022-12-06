using AppApi.Domain.Entities;
using AppApi.Dtos;
using AutoMapper;

namespace AppApi;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateBoardMessageDto, BoardMessageEntity>();

        CreateMap<BoardMessageEntity, BoardMessageDto>();
    }
}