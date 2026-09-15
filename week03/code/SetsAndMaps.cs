using System.Diagnostics;
using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    /// </summary>
    public static string[] FindPairs(string[] words)
    {
        var foundWords = new HashSet<string>();
        var pairs = new List<string>();

        foreach (var word in words)
        {
            var reversed = $"{word[1]}{word[0]}";

            if (foundWords.Contains(reversed))
            {
                pairs.Add($"{reversed} & {word}");
            }
            else
            {
                foundWords.Add(word);
            }
        }

        return pairs.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file. The degree information 
    /// is in the 4th column of the file. There is no header row.
    /// </summary>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            if (fields.Length > 3)
            {
                var degree = fields[3].Trim();
                if (degrees.ContainsKey(degree))
                {
                    degrees[degree]++;
                }
                else
                {
                    degrees[degree] = 1;
                }
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams using a dictionary.
    /// Ignores spaces and character case.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        var map = new Dictionary<char, int>();

        // Normalize strings: remove spaces and convert to lowercase
        var clean1 = word1.Replace(" ", "").ToLower();
        var clean2 = word2.Replace(" ", "").ToLower();

        if (clean1.Length != clean2.Length)
            return false;

        // Count frequencies of letters in word1
        foreach (var c in clean1)
        {
            if (map.ContainsKey(c))
                map[c]++;
            else
                map[c] = 1;
        }

        // Subtract frequencies using letters in word2
        foreach (var c in clean2)
        {
            if (!map.ContainsKey(c))
                return false;

            map[c]--;
            if (map[c] < 0)
                return false;
        }

        return true;
    }

    /// <summary>
    /// Read earthquake JSON data from the USGS website and return 
    /// a list of formatted descriptions of each earthquake's place and magnitude.
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        if (featureCollection?.Features == null)
        {
            return [];
        }

        var results = new List<string>();
        foreach (var feature in featureCollection.Features)
        {
            var place = feature.Properties?.Place ?? "Unknown location";
            var mag = feature.Properties?.Mag ?? 0.0;
            results.Add($"{place} - Mag {mag}");
        }

        return results.ToArray();
    }
}