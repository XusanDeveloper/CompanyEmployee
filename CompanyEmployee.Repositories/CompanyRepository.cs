using CompanyEmployee.Contracts;
using CompanyEmployee.Entities.Context;
using CompanyEmployee.Entities.Models;

namespace CompanyEmployee.Repositories
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        public IEnumerable<Company> GetAllCompanies(bool trackChanges) =>
            FindAll(trackChanges)
            .OrderBy(c => c.Name)
            .ToList();
    }
}