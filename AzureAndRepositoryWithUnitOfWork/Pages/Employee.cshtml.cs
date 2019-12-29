using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AzureAndRepositoryWithUnitOfWork.Repository;
using AzureAndRepositoryWithUnitOfWork.Repository.Entities;

namespace AzureAndRepositoryWithUnitOfWork.Pages
{
    public class EmployeeModel : PageModel
    {
        private IUnitOfWork _unitOfWork;

        public EmployeeModel(EmployeeDbContext employeeDbContext)
        {
            _unitOfWork = new UnitOfWork(employeeDbContext);
        }

        [BindProperty]
        public Employee Employee { get; set; }

        public  void OnGet(int? id)
        {
            if (id == null)
            {
                //return NotFound();
            }

            Employee = _unitOfWork.EmployeeRepository.Get(id);

            if (Employee == null)
            {
                //return NotFound();
            }
            //return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
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
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(Employee.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./EmployeeList");
        }

        private bool EmployeeExists(int id)
        {
            return _unitOfWork.EmployeeRepository.Get(id) != null ? true : false; 
        }
    }
}
