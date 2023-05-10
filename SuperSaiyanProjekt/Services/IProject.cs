using Models;

namespace SuperSaiyanProjekt.Services
{
    public interface IProject : IRepository<Project>
    {
        Task<IEnumerable<Employee>> GetEmployeesForProject(int projectId);
    }
}
