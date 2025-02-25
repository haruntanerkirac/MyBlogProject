using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace MyBlogProject.Controllers
{
    public class EmployeeTestController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7150/api/Default");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<Class1>>(jsonString);
            return View(values);
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(Class1 item)
        {
            var httpClient = new HttpClient();
            var jsonEmployee = JsonConvert.SerializeObject(item);
            StringContent content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:7150/api/Default", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(item);
        }

        [HttpGet]
        public async Task<IActionResult> EditEmployee(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7150/api/Default/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonEmployee = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<Class1>(jsonEmployee);
                return View(values);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> EditEmployee(Class1 item)
        {
            var httpClient = new HttpClient();
            var jsonEmployee = JsonConvert.SerializeObject(item);
            var content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PutAsync("https://localhost:7150/api/Default", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(item);
        }

        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.DeleteAsync("https://localhost:7150/api/Default/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }

    public class Class1
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
