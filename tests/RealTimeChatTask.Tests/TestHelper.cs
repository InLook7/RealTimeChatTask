using AutoMapper;
using RealTimeChatTask.BLL.Mappings;

namespace RealTimeChatTask.Tests;

public static class TestHelper
{
    public static IMapper ConfigureMapper()
    {
        var mapperConfiguration = new MapperConfiguration(config => 
        {
            config.AddProfile<BusinessLayerMapper>();
        });

        return mapperConfiguration.CreateMapper();
    }
}