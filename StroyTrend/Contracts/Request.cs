using System.Text.Json.Serialization;

namespace StroyTrend.Contracts;

public class Request
{
    [JsonPropertyName("distribution")]
    public string Distribution { get; set; }

    [JsonPropertyName("filters")]
    public Filters Filters { get; set; }
}