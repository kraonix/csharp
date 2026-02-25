using Microsoft.AspNetCore.Mvc;

public class DepartmentController : Controller
{
    public IActionResult Index()
    {
        return View(FakeDataStore.Departments);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Department department)
    {
        department.DepartmentId = FakeDataStore.DepartmentCounter++;
        FakeDataStore.Departments.Add(department);

        return RedirectToAction(nameof(Index));
    }
}