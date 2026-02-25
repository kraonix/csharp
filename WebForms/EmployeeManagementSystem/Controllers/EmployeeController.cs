using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

public class EmployeeController : Controller
{
    public IActionResult Index()
    {
        var employees = FakeDataStore.Employees
            .Select(e =>
            {
                e.Department = FakeDataStore.Departments
                    .FirstOrDefault(d => d.DepartmentId == e.DepartmentId);
                return e;
            })
            .ToList();

        return View(employees);
    }

    public IActionResult Create()
    {
        LoadDepartments();
        return View();
    }

    [HttpPost]
    public IActionResult Create(Employee employee)
    {
        employee.EmployeeId = FakeDataStore.EmployeeCounter++;
        FakeDataStore.Employees.Add(employee);

        return RedirectToAction(nameof(Index));
    }

    private void LoadDepartments()
    {
        ViewBag.Departments = new SelectList(
            FakeDataStore.Departments,
            "DepartmentId",
            "Name");
    }
}