using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureAndRepositoryWithUnitOfWork.Repository;
using AzureAndRepositoryWithUnitOfWork.Repository.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AzureAndRepositoryWithUnitOfWork.Pages
{
    public class AddEmployeeModel : PageModel
    {
        
        [BindProperty]
        public Employee Employee { get; set; }


        private IUnitOfWork _unitOfWork;
        public AddEmployeeModel(EmployeeDbContext employeeDbContext)
        {
            _unitOfWork = new UnitOfWork(employeeDbContext);
        }
        

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _unitOfWork.EmployeeRepository.Update(Employee);

            try
            {
                _unitOfWork.Save();
            }
            catch (Exception)
            {
                
            }

            return RedirectToPage("./EmployeeList");
        }
    }
}