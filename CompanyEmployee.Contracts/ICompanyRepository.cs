using CompanyEmployee.Entities.Models;

namespace CompanyEmployee.Contracts
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> GetAllCompanies(bool trackChanges);
    }
}
