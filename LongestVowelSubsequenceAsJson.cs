using System.Linq;
using System.Text.Json;
using System.Collections.Generic;

public class Pusula
{
    public static string LongestVowelSubsequenceAsJson(List<string> words)
    {
        if (words == null || words.Count == 0)
            return JsonSerializer.Serialize(words);

        string sesli = "aeıioöuü"; 
        var results = new List<object>();

        foreach (var word in words)
        {
            string best = "";
            string current = "";

            foreach (char c in word.ToLower())
            {
                if (sesli.Contains(c)) 
                {
                    current += c;
                    if (current.Length > best.Length)
                        best = current;
                }
                else
                {
                    current = "";
                }
            }

            results.Add(new
            {
                word = word,
                sequence = best,
                length = best.Length
            });
        }

        return JsonSerializer.Serialize(results);
    }
}
