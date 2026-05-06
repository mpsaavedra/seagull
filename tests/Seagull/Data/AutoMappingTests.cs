using System;
using System.Reflection;
using JasperFx.Core.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Seagull.Data;
using Seagull.Data.AutoMapping;
using Shouldly;

namespace Seagull.Tests.Data;

public class AutoMappingTests
{
    [Fact]
    public void AutoMapping_Mapping_FromDto_ShouldReturnDto()
    {
        var provider = GetProvider();
        var mapper = provider.GetRequiredService<AutoMapper.IMapper>();
        var entity = new FakeAutoMappingEntity
        {
            Id = 1,
            Entry1 = "Entry 1",
            Entry2 = 123
        };
        var dto = mapper.Map<FakeAutoMappingEntityDto>(entity);
        dto.Entry1.ShouldBe(entity.Entry1);
        dto.Entry2.ShouldBe(entity.Entry2);
    }

    [Fact]
    public void AutoMapping_Mapping_ToDto_ShouldReturnDto()
    {
        var provider = GetProvider();
        var mapper = provider.GetRequiredService<AutoMapper.IMapper>();
        var entity = new FakeAutoMappingEntity2
        {
            Id = 1,
            Entry1 = "Entry 1",
            Entry2 = 123
        };
        var dto = mapper.Map<FakeAutoMappingEntityDto2>(entity);
        dto.Entry1.ShouldBe(entity.Entry1);
        dto.Entry2.ShouldBe(entity.Entry2);
    }

    private IServiceProvider GetProvider()
    {
        var provider = new ServiceCollection()
            .AddAutoMapper(GetType().Assembly)
            .BuildServiceProvider();

        return provider;
    }
}

public class FakeAutoMapperProfile : AutoMapper.Profile
{
    public FakeAutoMapperProfile()
    {
        AutoMapping.LoadMapping(this, GetType().Assembly);
    }
}

public class FakeAutoMappingEntity
{
    public int Id { get; set; }
    public string Entry1 { get; set; }
    public int Entry2 { get; set; }
}

public sealed record FakeAutoMappingEntityDto : IMap<FakeAutoMappingEntity>
{
    public int Id { get; set; }
    public string Entry1 { get; set; }
    public int Entry2 { get; set; }
}

public class FakeAutoMappingEntity2 : IMap<FakeAutoMappingEntityDto2>
{
    public int Id { get; set; }
    public string Entry1 { get; set; }
    public int Entry2 { get; set; }
}

public sealed record FakeAutoMappingEntityDto2
{
    public int Id { get; set; }
    public string Entry1 { get; set; }
    public int Entry2 { get; set; }
}
