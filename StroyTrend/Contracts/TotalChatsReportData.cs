using System.Text.Json.Serialization;

namespace StroyTrend.Contracts;

public class TotalChatsReportData
{
    [JsonPropertyName("total")]
    public int Total { get; set; }
}