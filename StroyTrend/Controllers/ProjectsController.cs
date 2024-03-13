using Microsoft.AspNetCore.Mvc;
using StroyTrend.Repositories.Projects;

namespace StroyTrend.Controllers;

[ApiController, Route("/api/projects")]
public class ProjectsController(IProjectsRepository projectsRepository) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var projects = await projectsRepository.GetAll(cancellationToken);
        return Ok(projects);
    }
    
    [HttpGet("{projectId:int}")]
    public async Task<IActionResult> Get(int projectId, CancellationToken cancellationToken)
    {
        var project = await projectsRepository.GetById(projectId, cancellationToken);
        return Ok(project);
    }
}