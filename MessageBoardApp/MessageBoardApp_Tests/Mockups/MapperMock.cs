using MessageBoard;
using AutoMapper;

namespace MessageBoardApp_Tests.Mockups;

public static class MapperMock
{
    public static IMapper CreateMapper()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile(typeof(MappingProfile)));
        var mapper = new Mapper(config);

        return mapper;
    }
}