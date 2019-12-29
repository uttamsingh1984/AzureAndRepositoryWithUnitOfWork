using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureAndRepositoryWithUnitOfWork.Repository.Entities
{
    public class Employee :Entity
    {
        public string Name { get; set; }
        public string City { get; set; }
        public int Salary { get; set; }
    }
}
