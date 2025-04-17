namespace Algorithms;

public class DamerauLevenshtein
{
    public static int DamerauLevenshteinRestrictedResult(string s1, string s2)
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

    public static int DamerauLevenshteinUnrestrictedResult(string s1, string s2)
    {
        var da = new Dictionary<char, int>();
        var len1 = s1.Length;
        var len2 = s2.Length;
        var maxDist = len1 + len2;

        var d = new int[len1 + 2, len2 + 2];

        d[0, 0] = maxDist;

        for (var i = 0; i <= len1; i++)
        {
            d[i + 1, 0] = maxDist;
            d[i + 1, 1] = i;
        }

        for (var j = 0; j <= len2; j++)
        {
            d[0, j + 1] = maxDist;
            d[1, j + 1] = j;
        }

        foreach (var c in s1.Concat(s2))
        {
            if (!da.ContainsKey(c))
                da[c] = 0;
        }

        for (var i = 1; i <= len1; i++)
        {
            var db = 0;
            for (var j = 1; j <= len2; j++)
            {
                var i1 = da[s2[j - 1]];
                var j1 = db;

                var cost = s1[i - 1] == s2[j - 1] ? 0 : 1;
                if (cost == 0)
                    db = j;

                d[i + 1, j + 1] = Math.Min(
                    Math.Min(d[i, j] + cost,                // substitution
                        d[i + 1, j] + 1),              // insertion
                    Math.Min(d[i, j + 1] + 1,               // deletion
                        d[i1, j1] + (i - i1 - 1) + 1 + (j - j1 - 1)) // transposition
                );
            }

            da[s1[i - 1]] = i;
        }

        return d[len1 + 1, len2 + 1];
    }

}
