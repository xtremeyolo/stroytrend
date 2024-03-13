using System.Text.Json.Serialization;

namespace StroyTrend.Contracts;

public class ResponseTimeReportData
{
    [JsonPropertyName("count")]
    public int Count { get; set; }
    
    [JsonPropertyName("response_time")]
    public double ResponseTime { get; set; }
}