using AutoMapper;
using MessageBoardApp.Application.Service.Dtos;
using MessageBoardApp.Domain.Entities;

namespace MessageBoardApp.Application;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateBoardMessageDto, BoardMessageEntity>();

        CreateMap<BoardMessageEntity, BoardMessageDto>();
    }
}