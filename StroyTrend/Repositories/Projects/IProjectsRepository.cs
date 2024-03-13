using StroyTrend.Contracts;

namespace StroyTrend.Repositories.Projects;

public interface IProjectsRepository
{
    public ValueTask<ICollection<ProjectDto>> GetAll(CancellationToken cancellationToken);
    public ValueTask<ProjectDto?> GetById(int id, CancellationToken cancellationToken);
}