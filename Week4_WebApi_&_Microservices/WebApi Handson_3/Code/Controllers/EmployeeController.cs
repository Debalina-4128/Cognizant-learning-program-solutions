using Microsoft.AspNetCore.Mvc;
using WebApi_Handson_3.Filters;
using WebApi_Handson_3.Models;

namespace WebApi_Handson_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(CustomAuthFilter))] // Apply Authorization Filter
    public class EmployeeController : ControllerBase
    {
        private List<Employee> _employeeList;

        public EmployeeController()
        {
            _employeeList = GetStandardEmployeeList();
        }

        private List<Employee> GetStandardEmployeeList()
        {
            return new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Name = "John Doe",
                    Salary = 50000,
                    Permanent = true,
                    DateOfBirth = new DateTime(1990, 5, 15),
                    Department = new Department { Id = 1, Name = "HR" },
                    Skills = new List<Skill>
                    {
                        new Skill { Id = 1, Name = "Communication" },
                        new Skill { Id = 2, Name = "Recruitment" }
                    }
                },
                new Employee
                {
                    Id = 2,
                    Name = "Jane Smith",
                    Salary = 60000,
                    Permanent = false,
                    DateOfBirth = new DateTime(1985, 10, 20),
                    Department = new Department { Id = 2, Name = "IT" },
                    Skills = new List<Skill>
                    {
                        new Skill { Id = 3, Name = "C#" },
                        new Skill { Id = 4, Name = "SQL" }
                    }
                }
            };
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<Employee>> Get()
        {
            // ❗Simulate an exception for testing the CustomExceptionFilter
            throw new Exception("Something went wrong!");
            // return Ok(_employeeList); // Keep this when exception is not needed
        }

        [HttpGet("standard")]
        public ActionResult<Employee> GetStandard()
        {
            return Ok(_employeeList.First());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            _employeeList.Add(employee);
            return Ok("Added");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Employee updated)
        {
            var emp = _employeeList.FirstOrDefault(e => e.Id == id);
            if (emp == null) return NotFound();
            emp.Name = updated.Name;
            emp.Department = updated.Department;
            return Ok("Updated");
        }
    }
}
