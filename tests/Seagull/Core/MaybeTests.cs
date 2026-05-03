using System;
using Seagull;
using Shouldly;

namespace Seagull.Tests.Core;

public class MaybeTests
{
    [Fact]
    public void Maybe_From_ShouldReturnValue()
    {
        var data = "simple";

        var d = Maybe<string>.From(data);

        d.ShouldBe(data);
    }
}
