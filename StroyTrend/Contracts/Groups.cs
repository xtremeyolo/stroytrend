using System.Text.Json.Serialization;

namespace StroyTrend.Contracts;

public class Groups
{
    [JsonPropertyName("values")]
    public List<int> Values { get; set; }
}