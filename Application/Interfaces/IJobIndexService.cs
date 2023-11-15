using Domain.Entities;

namespace Application.Interfaces
{
    public interface IJobIndexService
    {
        Task IndexJobAsync(Job job);
    }
}
