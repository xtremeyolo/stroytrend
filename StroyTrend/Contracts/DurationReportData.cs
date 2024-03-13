using System.Text.Json.Serialization;

namespace StroyTrend.Contracts;

// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);

public class DurationReportData
{
    [JsonPropertyName("agents_chatting_duration")]
    public int AgentsChattingDuration { get; set; }

    [JsonPropertyName("count")]
    public int Count { get; set; }

    [JsonPropertyName("duration")]
    public int Duration { get; set; }
}