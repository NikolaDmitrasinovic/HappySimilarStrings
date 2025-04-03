using Algorithms;

namespace AlgorithmTests;

public class JaroWinklerTests
{
    [Fact]
    public void IdenticalStrings_ShouldReturn1()
    {
        Assert.Equal(1, JaroWinkler.JaroWinklerResult("hello", "hello"));
    }

    [Fact]
    public void CompletelyDifferentStrings_ShouldReturn0()
    {
        Assert.Equal(0, JaroWinkler.JaroWinklerResult("abc", "zyx"));
    }

    [Fact]
    public void CloseMatch_ShouldReturnHighScore()
    {
        var score = JaroWinkler.JaroWinklerResult("helo", "hello");
        Assert.InRange(score, 0.95, 1.0);
    }

    [Fact]
    public void TransposedLetters_ShouldHaveLowerScore()
    {
        var score = JaroWinkler.JaroWinklerResult("hleol", "hello");
        Assert.InRange(score, 0.8, 0.9);
    }
}
