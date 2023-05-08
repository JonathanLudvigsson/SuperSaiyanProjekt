using Models;

namespace SuperSaiyanProjekt.Services
{
    public class EmployeeRepo : IRepository<Employee>
    {

        public Task<Employee> Add(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Employee>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Employee> Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> Update(int id, Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
