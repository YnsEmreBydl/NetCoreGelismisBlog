using BlogApi.DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {

        [HttpGet]
     
    public IActionResult EmployeeList()
        {
            using var c = new Context();

            var values = c.Employees.ToList();

            //Ok = apilerde geri dönecek, başarılı olan status kodu
            return Ok(values);
        }

        [HttpPost]
        public IActionResult EmpoyeeAdd(Employee emp)
        {
            using var c = new Context();

            c.Add(emp);

            c.SaveChanges();
            return Ok();
        }

        [HttpGet("{id}")]

        public IActionResult EmployeeGet(int id)
        {
            using var c = new Context();

            var employee = c.Employees.Find(id);

            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(employee);
            }

           
        }
        [HttpDelete("{id}")]

        public IActionResult EmployeeDelete(int id)
        {
            using var c = new Context();
            var employee = c.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                c.Remove(employee);
                c.SaveChanges();
                return Ok();
            }
        }

        [HttpPut]

        public IActionResult EmployeeUpdate(Employee employee)
        {
            using var c = new Context();

            var emp = c.Find<Employee>(employee.EmployeeID);
            if (emp == null)
            {
                return NotFound();
            }
            else
            {
                emp.EmployeName = employee.EmployeName;
                c.Update(emp);
                c.SaveChanges();

                return Ok();
            }
        }

    }
}
