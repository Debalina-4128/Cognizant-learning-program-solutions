using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi_Handson_2.Models;

namespace WebApi_Handson_2.Controllers
{
    [Route("api/emp")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> Get()
        {
            var employees = new List<Employee>
            {
                new Employee { Id = 1, Name = "John", Department = "HR" },
                new Employee { Id = 2, Name = "Jane", Department = "IT" },
                new Employee { Id = 3, Name = "Alice", Department = "Finance" },
                new Employee { Id = 4, Name = "Bob", Department = "Sales" }
            };

            return Ok(employees);
        }
    }
}
