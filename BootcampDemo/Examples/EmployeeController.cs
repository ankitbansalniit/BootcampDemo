using System.Data.Entity;

namespace BootcampDemo.Examples
{
    public class EmployeeController
    {
        private EmployeeContext _db;

        public EmployeeController()
        {
            _db = new EmployeeContext();
        }

        public ActionResult DeleteEmployee(int id)
        {
            var employee = _db.Employees.Find(id);
            _db.Employees.Remove(employee);
            _db.SaveChanges();
            return RedirectToAction("Employees");
        }

        private ActionResult RedirectToAction(string employees)
        {
            return new RedirectResult();
        }
    }

    public partial class ActionResult { }

    public class RedirectResult : ActionResult { }

    public class EmployeeContext
    {
        public DbSet<Employee> Employees { get; set; }

        public void SaveChanges()
        {
        }
    }

    public class Employee
    {
    }
}