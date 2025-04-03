namespace Algorithms;

public static class JaroWinkler
{
    public static double JaroWinklerResult(string s1, string s2)
    {
        if(s1 == s2) return 1;

        var matchDistance = Math.Max(s1.Length, s2.Length);
        var s1Matches = new bool[s1.Length];
        var s2Matches = new bool[s2.Length];

        var matches = 0;

        for (var i = 0; i < s1.Length; i++)
        {
            var start = Math.Max(0, i - matchDistance);
            var end = Math.Min(i + matchDistance + 1, s2.Length);

            for (var j = start; j < end; j++)
            {
                if (s2Matches[j] || s1[i] != s2[j]) continue;

                s1Matches[i] = s2Matches[j] = true;
                matches++;
                break;
            }
        }

        if (matches == 0) return 0;

        var transpositions = 0;
        var k = 0;

        for (var i = 0; i < s1.Length; i++)
        {
            if (!s1Matches[i]) continue;
            while (!s2Matches[k]) k++;
            if (s1[i] != s2[i]) transpositions++;
            k++;
        }

        transpositions /= 2;

        var jaro = (matches / (double)s1.Length +
                    matches / (double)s2.Length +
                    (matches - transpositions) / (double)matches) / 3.0;

        var prefixLength = 0;

        for (var i = 0; i < Math.Min(4, s1.Length); i++)
        {
            if (s1[i] == s2[i]) prefixLength++;
            else break;
        }

        return jaro + prefixLength * 0.1 * (1 - jaro);
    }
}
