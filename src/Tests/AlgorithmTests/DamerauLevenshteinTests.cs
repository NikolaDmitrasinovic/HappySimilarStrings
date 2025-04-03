using Algorithms;

namespace AlgorithmTests;

public class DamerauLevenshteinTests
{
    [Fact]
    public void IdenticalWords_ShouldReturn0()
    {
        Assert.Equal(0, DamerauLevenshtein.DamerauLevenshteinResult("hello", "hello"));
    }

    [Fact]
    public void SingleCharacterChange_ShouldReturnOne()
    {
        Assert.Equal(1, DamerauLevenshtein.DamerauLevenshteinResult("hello", "hallo"));
    }
}
