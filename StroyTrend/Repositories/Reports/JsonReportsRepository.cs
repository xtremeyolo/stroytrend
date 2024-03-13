using System.Text.Json;
using StroyTrend.Contracts;

namespace StroyTrend.Repositories.Reports;

public class JsonReportsRepository: IReportsRepository
{
    public async ValueTask<Report<DateOnly, TotalChatsReportData>> GetTotalChats(CancellationToken cancellationToken)
    {
        await using var stream = File.OpenRead("./Data/total-chats-report.json");
        var result = await JsonSerializer.DeserializeAsync<Report<DateOnly, TotalChatsReportData>>(stream, cancellationToken: cancellationToken);
        return result;
    }

    public async ValueTask<Report<DateOnly, RatingsReportData>> GetRatings(CancellationToken cancellationToken)
    {
        await using var stream = File.OpenRead("./Data/ratings-report.json");
        var result = await JsonSerializer.DeserializeAsync<Report<DateOnly, RatingsReportData>>(stream, cancellationToken: cancellationToken);
        return result;
    }

    public async ValueTask<Report<DateOnly, ResponseTimeReportData>> GetResponseTime(CancellationToken cancellationToken)
    {
        await using var stream = File.OpenRead("./Data/response-time-report.json");
        var result = await JsonSerializer.DeserializeAsync<Report<DateOnly, ResponseTimeReportData>>(stream, cancellationToken: cancellationToken);
        return result;
    }

    public async ValueTask<Report<DateOnly, TagsReportData>> GetTags(CancellationToken cancellationToken)
    {
        await using var stream = File.OpenRead("./Data/tags-report.json");
        var result = await JsonSerializer.DeserializeAsync<Report<DateOnly, TagsReportData>>(stream, cancellationToken: cancellationToken);
        return result;
    }

    public async ValueTask<Report<DateOnly, DurationReportData>> GetDuration(CancellationToken cancellationToken)
    {
        await using var stream = File.OpenRead("./Data/duration-report.json");
        var result = await JsonSerializer.DeserializeAsync<Report<DateOnly, DurationReportData>>(stream, cancellationToken: cancellationToken);
        return result;
    }
}