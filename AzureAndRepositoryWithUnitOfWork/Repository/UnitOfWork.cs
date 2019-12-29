using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureAndRepositoryWithUnitOfWork.Repository
{
    public interface IUnitOfWork :IDisposable
    {
        EmployeeRepository EmployeeRepository { get; }
        QualificationRepository QualificationRepository { get; }

        void Save();
    }

    public class UnitOfWork :IUnitOfWork
    {
        private EmployeeRepository _employeeRepository;
        private QualificationRepository _qualificationRepository;

        private EmployeeDbContext _dbContext;
        public UnitOfWork(EmployeeDbContext employeeDbContext)
        {
            _dbContext = employeeDbContext;
        }

        public EmployeeRepository EmployeeRepository
        {
            get
            {
                if(_employeeRepository == null)
                {
                    _employeeRepository = new EmployeeRepository(_dbContext);
                }
                return _employeeRepository;
            }
        }

        public QualificationRepository QualificationRepository
        {
            get
            {
                if (_qualificationRepository == null)
                {
                    _qualificationRepository = new QualificationRepository(_dbContext);
                }
                return _qualificationRepository;
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
                _dbContext = null;
            }
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
