using Algorithms;

namespace AlgorithmTests;

public class JaroWinklerTests
{
    [Fact]
    public void IdenticalWords_ShouldReturn1()
    {
        Assert.Equal(1, JaroWinkler.JaroWinklerResult("hello", "hello"));
    }
}
