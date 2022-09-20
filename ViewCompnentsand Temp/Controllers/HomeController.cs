using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ViewCompnentsand_Temp.Models;
using Newtonsoft.Json;

namespace ViewCompnentsand_Temp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var OldList = JsonConvert.SerializeObject(new List<Student>());

            TempData["List"] = OldList;

            return View();
        }

        int increment = 0;
        [HttpPost]
        public IActionResult Index(Student s, IFormCollection form)
        {
            string clickCount = form["Id"];
            if (clickCount == "")
            {
                increment = +1;
                @TempData["CommentCount"] = increment;
            }
            else
            {
                int m = Int32.Parse(clickCount);
                if (m > 0)
                {
                    m++;
                    @TempData["CommentCount"] = m;
                }
            }
            var NewList = JsonConvert.DeserializeObject<List<Student>>(TempData["List"].ToString());
            NewList.Add(s);

            TempData["List"] = JsonConvert.SerializeObject(NewList);

            return View();
        }
    }
}