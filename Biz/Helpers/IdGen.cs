

namespace Biz.Helpers;

public static class IdGen
{
    public static string Generate() => Guid.NewGuid().ToString();
}
