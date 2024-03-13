using System.Collections.Concurrent;
using StroyTrend.Contracts;

namespace StroyTrend.Repositories.Projects;

public class InMemoryProjectsRepository: IProjectsRepository
{
    private readonly ConcurrentDictionary<int, ProjectDto> _projects = new();
    private bool _isSeeded;
    private readonly object _seedLock = new();
    
    public ValueTask<ICollection<ProjectDto>> GetAll(CancellationToken cancellationToken)
    {
        if(!_isSeeded)
            Seed();

        return ValueTask.FromResult(_projects.Values);
    }

    public ValueTask<ProjectDto?> GetById(int id, CancellationToken cancellationToken)
    {
        if(!_isSeeded)
            Seed();

        _projects.TryGetValue(id, out var project);

        return ValueTask.FromResult(project);
    }


    private void Seed()
    {
        lock (_seedLock)
        {
            if(_isSeeded)
                return;
            
            foreach (var r in Enumerable.Range(1, 10))
            {
                _projects.TryAdd(r, new ProjectDto()
                {
                    Id = r,
                    Name = $"Project {r}",
                    Description = "Lorem ipsum dolor sit amet consectetur adipiscing elit magnis dis, ac duis suspendisse orci diam tincidunt varius."
                });
            }

            _isSeeded = true;
        }
    }
}