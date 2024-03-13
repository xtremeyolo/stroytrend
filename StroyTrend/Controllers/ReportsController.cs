using Microsoft.AspNetCore.Mvc;
using StroyTrend.Repositories.Reports;

namespace StroyTrend.Controllers;

[ApiController, Route("/api/reports")]
public class ReportsController(IReportsRepository reportsRepository) : ControllerBase
{
    [HttpGet("total-chats")]
    public async ValueTask<IActionResult> GetTotalChats(CancellationToken cancellationToken)
    {
        var result = await reportsRepository.GetTotalChats(cancellationToken);
        return Ok(result);
    }
    
    [HttpGet("ratings")]
    public async ValueTask<IActionResult> GetRatings(CancellationToken cancellationToken)
    {
        var result = await reportsRepository.GetRatings(cancellationToken);
        return Ok(result);
    }
    
    [HttpGet("response-time")]
    public async ValueTask<IActionResult> GetResponseTime(CancellationToken cancellationToken)
    {
        var result = await reportsRepository.GetResponseTime(cancellationToken);
        return Ok(result);
    }
    
    [HttpGet("tags")]
    public async ValueTask<IActionResult> GetTags(CancellationToken cancellationToken)
    {
        var result = await reportsRepository.GetTags(cancellationToken);
        return Ok(result);
    }
    
    [HttpGet("duration")]
    public async ValueTask<IActionResult> GetDuration(CancellationToken cancellationToken)
    {
        var result = await reportsRepository.GetDuration(cancellationToken);
        return Ok(result);
    }
    
}