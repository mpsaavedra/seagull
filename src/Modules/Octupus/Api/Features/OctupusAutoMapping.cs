using System;
using Seagull.Data.AutoMapping;

namespace Octupus.Api.Features;

public class OctupusAutoMapping : AutoMapper.Profile
{
    public OctupusAutoMapping()
    {
        AutoMapping.LoadMapping(this, GetType().Assembly);
    }
}
