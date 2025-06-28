using Microsoft.AspNetCore.Mvc;
using smSystem.Models;

public class HomeController : Controller
{
    public static List<School> Schools = new();
    public Stats st = new();
    public static int SchoolId = 1;
    public IActionResult Index()
    {

        st.TotalSchool = Schools.Count();
        int cnt = 0;
        foreach (var sc in Schools)
        {
            cnt += sc.students.Count();
        }
        st.TotalStudent = cnt;
        return View(st);
    }
    public IActionResult AddSchool() => View();

    [HttpPost]
    public IActionResult AddSchool(School school)
    {
        school.SchoolId = "SCH###" + SchoolId++;
        Schools.Add(school);
        return RedirectToAction("AddSchool");
    }
    public IActionResult AddStudent() => View(Schools);
    [HttpPost]
    public IActionResult AddStudent(Student student)
    {
        var school = Schools.FirstOrDefault(s => s.SchoolId == student.SchoolId);
        if (school != null)
        {

            school.students.Add(student);
        }
        return RedirectToAction("AddStudent");
    }
    public IActionResult ViewData() => View(Schools);
}