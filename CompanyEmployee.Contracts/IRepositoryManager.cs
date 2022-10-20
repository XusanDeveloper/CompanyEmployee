using CompanyEmployee.Contracts;

namespace CompanyEmployee.Repositories
{
    public interface IRepositoryManager
    {
        ICompanyRepository Company { get; }
        IEmployeeRepository Employee { get; }
        Task SaveAsync();
    }
}
