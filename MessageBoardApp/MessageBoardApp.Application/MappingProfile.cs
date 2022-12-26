using AppApi.Domain.Entities;
using AutoMapper;
using MessageBoardApp.Application.Service.Dtos;

namespace AppApi;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateBoardMessageDto, BoardMessageEntity>();

        CreateMap<BoardMessageEntity, BoardMessageDto>();
    }
}