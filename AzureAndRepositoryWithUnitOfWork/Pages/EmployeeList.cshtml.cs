using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureAndRepositoryWithUnitOfWork.Repository;
using AzureAndRepositoryWithUnitOfWork.Repository.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AzureAndRepositoryWithUnitOfWork.Pages
{
    public class EmployeeListModel : PageModel
    {
        private IUnitOfWork _unitOfWork;
        public EmployeeListModel(EmployeeDbContext employeeDbContext)
        {
            Employees = new List<Employee>();
            _unitOfWork = new UnitOfWork(employeeDbContext);

        }
        public List<Employee> Employees { get; set; }
        public void OnGet()
        {
            Employees=_unitOfWork.EmployeeRepository.GetAll().ToList();

        }

        
        public IActionResult OnGetDelEmployee(int Id)
        {
            _unitOfWork.EmployeeRepository.Remove(Id);
            _unitOfWork.Save();
            return new JsonResult(new { Suceess=true  });
        }
    }

    //public class Employee
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }        
    //    public string City { get; set; }
    //    public int Salary { get; set; }
    //}
}