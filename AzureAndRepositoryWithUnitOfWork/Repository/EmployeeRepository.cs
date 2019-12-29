using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AzureAndRepositoryWithUnitOfWork.Repository.Entities;

namespace AzureAndRepositoryWithUnitOfWork.Repository
{
    public interface IEmployeeRepository : IRepository<Employee> 
    {
        IEnumerable<Employee> GetEmployeeByName(string name);
    }

    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        EmployeeDbContext _employeeDbContext;
        public EmployeeRepository(EmployeeDbContext employeeDbContext) : base(employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }

        public IEnumerable<Employee> GetEmployeeByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
