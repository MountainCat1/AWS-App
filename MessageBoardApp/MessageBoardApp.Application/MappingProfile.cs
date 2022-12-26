using AutoMapper;
using MessageBoardApp.Application.Domain.Entities;
using MessageBoardApp.Application.Service.Dtos;

namespace MessageBoardApp.Application;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateBoardMessageDto, BoardMessageEntity>();

        CreateMap<BoardMessageEntity, BoardMessageDto>();
    }
}