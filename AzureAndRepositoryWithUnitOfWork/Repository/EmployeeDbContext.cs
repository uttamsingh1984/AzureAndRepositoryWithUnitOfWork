using AzureAndRepositoryWithUnitOfWork.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureAndRepositoryWithUnitOfWork.Repository
{
    public class EmployeeDbContext :DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        { }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Qualification> Qualifications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Qualification>().ToTable("Qualifications").HasKey(x => x.Id);

            modelBuilder.Entity<Employee>().ToTable("Employees").HasKey(x => x.Id);
        }
    }
}
