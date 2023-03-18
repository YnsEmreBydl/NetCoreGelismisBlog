using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.DataAccessLayer
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        public string EmployeName { get; set; }
    }
}
