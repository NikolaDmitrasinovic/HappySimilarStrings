using Algorithms;

namespace AlgorithmTests;

public class DamerauLevenshteinTests
{
    [Fact]
    public void IdenticalWords_ShouldReturn0()
    {
        Assert.Equal(0, DamerauLevenshtein.DamerauLevenshteinResult("hello", "hello"));
    }
}
