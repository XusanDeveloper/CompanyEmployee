using CompanyEmployee.Contracts;
using CompanyEmployee.Entities.Context;
using CompanyEmployee.Entities.Models;

namespace CompanyEmployee.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

    }
}
