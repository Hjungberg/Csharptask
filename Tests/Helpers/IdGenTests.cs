
using Biz.Helpers;

namespace Tests.Helpers;

public class IdGenTests
{
    [Fact]
    public void Generate_ShouldReturnGuidAsString()
    {
        var result = IdGen.Generate();

        Assert.NotNull(result);
        Assert.True(Guid.TryParse(result, out Guid _));
    }

}
