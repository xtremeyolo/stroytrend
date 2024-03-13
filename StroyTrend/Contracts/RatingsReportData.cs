using System.Text.Json.Serialization;

namespace StroyTrend.Contracts;

public class RatingsReportData
{
    [JsonPropertyName("chats")]
    public int Chats { get; set; }
    
    [JsonPropertyName("bad")]
    public int Bad { get; set; }
    
    [JsonPropertyName("good")]
    public int Good { get; set; }
}