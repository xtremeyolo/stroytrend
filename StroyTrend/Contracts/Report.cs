using System.Text.Json.Serialization;

namespace StroyTrend.Contracts;

public class Report<TKey,TValue> where TKey : notnull
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("request")]
    public Request Request { get; set; }

    [JsonPropertyName("total")]
    public int Total { get; set; }

    [JsonPropertyName("records")] public Dictionary<TKey, TValue> Records { get; set; } = new();
}