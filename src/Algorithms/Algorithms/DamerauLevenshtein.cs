namespace Algorithms;

public class DamerauLevenshtein
{
    public static int DamerauLevenshteinResult(string s1, string s2)
    {
        var len1 = s1.Length;
        var len2 = s2.Length;

        var dp = new int[len1 + 1, len2 + 1];

        for (var i = 0; i < len1; i++) dp[i, 0] = i;
        for (var i = 0; i < len2; i++) dp[0, i] = i;

        for (var i = 1; i <= len1; i++)
        {
            for (var j = 1; j <= len2; j++)
            {
                var cost = (s1[i - 1] == s2[j - 1]) ? 0 : 1;

                dp[i, j] = Math.Min(
                    Math.Min(dp[i - 1, j] + 1,
                        dp[i, j - 1] + 1),
                    dp[i - 1, j - 1] + cost
                );

                if (i > 1 && j > 1 && s1[i - 1] == s2[j - 2] && s1[i - 2] == s2[j - 1])
                {
                    dp[i, j] = Math.Min(dp[i, j], dp[i - 2, j - 2] + cost);
                }
            }
        }

        return dp[len1, len2];
    }
}
