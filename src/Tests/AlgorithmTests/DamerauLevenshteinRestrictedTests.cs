using Algorithms;

namespace AlgorithmTests;

public class DamerauLevenshteinRestrictedTests
{
    [Fact]
    public void IdenticalWords_ShouldReturn0()
    {
        Assert.Equal(0, DamerauLevenshtein.DamerauLevenshteinRestrictedResult("hello", "hello"));
    }

    [Fact]
    public void SingleCharacterChange_ShouldReturn1()
    {
        Assert.Equal(1, DamerauLevenshtein.DamerauLevenshteinRestrictedResult("hello", "hallo"));
    }

    [Fact]
    public void OneInsertion_ShouldReturn1()
    {
        Assert.Equal(1, DamerauLevenshtein.DamerauLevenshteinRestrictedResult("car", "char"));
    }

    [Fact]
    public void OneDeletion_ShouldReturn1()
    {
        Assert.Equal(1, DamerauLevenshtein.DamerauLevenshteinRestrictedResult("char", "car"));
    }

    [Fact]
    public void OneTransposition_ShouldReturn1()
    {
        Assert.Equal(1, DamerauLevenshtein.DamerauLevenshteinRestrictedResult("hlelo", "hello"));
    }

    [Theory]
    [InlineData("dog", "god", 2)]
    [InlineData("kitten", "sitting", 3)]
    [InlineData("abcd", "efgh", 4)]
    public void MultipleEdits_ShouldReturnCorrectDistance(string s1, string s2, int distance)
    {
        Assert.Equal(distance, DamerauLevenshtein.DamerauLevenshteinRestrictedResult(s1, s2));
    }
}
