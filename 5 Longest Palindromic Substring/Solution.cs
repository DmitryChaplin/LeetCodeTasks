public class Solution
{
    public string LongestPalindrome(string s)
    {
        // edge case check
        if (s.Length < 2)
            return s;

        // let's declare a Tuple to store a start/end indices of a longest palindrome
        var longestPalindrome = new Tuple<int, int>(0, 0);

        for (int i = 0; i < s.Length - 1; i++)
        {
            // Check if we have a s1+s2 (e.g.: [abc][cba]) case, by checking the next char and expanding around current and next character
            if (s[i] == s[i + 1])
            {
                var result = Expand(s, i, i + 1);
                // if number of chars in our palindrome is bigger than in the previous one, we record our new longest palindrome 
                longestPalindrome = result.Item2 - result.Item1 > longestPalindrome.Item2 - longestPalindrome.Item1 
                    ? result 
                    : longestPalindrome;
            }

            // Check if we have a s1+(?)+s2 (e.g.: [abc]f[cba]) case, by checking the i+2 char and expanding around current it and the current char
            if (i + 2 < s.Length && s[i] == s[i + 2])
            {
                var result = Expand(s, i, i + 2);
                // same check as before
                longestPalindrome = result.Item2 - result.Item1 > longestPalindrome.Item2 - longestPalindrome.Item1
                    ? result
                    : longestPalindrome;
            }
        }

        return longestPalindrome.Item1 == 0 && longestPalindrome.Item2 == 0 
            ? s[0].ToString() 
            : s.Substring(longestPalindrome.Item1, longestPalindrome.Item2 - longestPalindrome.Item1 + 1);
    }

    Tuple<int, int> Expand(string s, int start, int end)
    {
        // keep expanding while we are in bounds of the string length and characters on both ends are the same
        while (start >= 0 && end < s.Length && s[start] == s[end])
        {
            start--;
            end++;
        }

        return new Tuple<int, int>(start + 1, end - 1);
    }
}