using BlogApiDemo.DataAccessLayer;
using Microsoft.AspNetCore.Mvc;

namespace BlogApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public IActionResult EmployeeList()
        {
            using var context = new Context();
            var values = context.Employees.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            using var context = new Context();
            context.Employees.Add(employee);
            context.SaveChanges();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            using var context = new Context();
            var value = context.Employees.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(value);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            using var context = new Context();
            var employee = context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                context.Remove(employee);
                context.SaveChanges();
                return Ok();
            }
        }

        [HttpPut]
        public IActionResult UpdateEmployee(Employee employee)
        {
            using var context = new Context();
            var item = context.Employees.Find(employee.ID);
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                item.Name = employee.Name;
                context.Update(item);
                context.SaveChanges();
                return Ok();
            }
        }
    }
}
