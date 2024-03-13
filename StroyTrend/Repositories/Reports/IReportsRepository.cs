using StroyTrend.Contracts;

namespace StroyTrend.Repositories.Reports;

public interface IReportsRepository
{
    public ValueTask<Report<DateOnly,TotalChatsReportData>> GetTotalChats(CancellationToken cancellationToken);
    public ValueTask<Report<DateOnly, RatingsReportData>> GetRatings(CancellationToken cancellationToken);
    public ValueTask<Report<DateOnly, ResponseTimeReportData>> GetResponseTime(CancellationToken cancellationToken);
    public ValueTask<Report<DateOnly, TagsReportData>> GetTags(CancellationToken cancellationToken);
    public ValueTask<Report<DateOnly, DurationReportData>> GetDuration(CancellationToken cancellationToken);
}