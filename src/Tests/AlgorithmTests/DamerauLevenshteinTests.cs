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
    public void SingleCharacterChange_ShouldReturn1()
    {
        Assert.Equal(1, DamerauLevenshtein.DamerauLevenshteinResult("hello", "hallo"));
    }

    [Fact]
    public void OneInsertion_ShouldReturn1()
    {
        Assert.Equal(1, DamerauLevenshtein.DamerauLevenshteinResult("helo", "hello"));
    }

    [Fact]
    public void OneDeletion_ShouldReturn1()
    {
        Assert.Equal(1, DamerauLevenshtein.DamerauLevenshteinResult("hello", "helo"));
    }

    [Fact]
    public void OneTransposition_ShouldReturn1()
    {
        Assert.Equal(1, DamerauLevenshtein.DamerauLevenshteinResult("hlelo", "hello"));
    }
}
