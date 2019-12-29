using AzureAndRepositoryWithUnitOfWork.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureAndRepositoryWithUnitOfWork.Repository
{
    public interface IQualificationRepository : IRepository<Qualification>
    {
        IEnumerable<Qualification> GetQualificationsByName(string name);

    }

    public class QualificationRepository : Repository<Qualification>, IQualificationRepository
    {
        EmployeeDbContext _employeeDbContext;
        public QualificationRepository(EmployeeDbContext employeeDbContext) : base(employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }

        public IEnumerable<Qualification> GetQualificationsByName(string name)
        {
           return _employeeDbContext.Qualifications.Where(x => x.Name == name);
        }
    }
}
