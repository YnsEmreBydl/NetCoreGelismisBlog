using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreGelismisBlog.Controllers
{
  
    public class EmployeeTest : Controller
    {
        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
       
            var responseMessage = await httpClient.GetAsync("https://localhost:44320/api/Default");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<Class1>>(jsonString);
            return View(values);
        }
        [HttpGet]
        public IActionResult AddEpmloyee()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddEpmloyee(Class1 cs)
        {
            var httpClient = new HttpClient();

            var jsonEmployee = JsonConvert.SerializeObject(cs);
            StringContent content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:44320/api/Default", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "EmployeeTest");
            }

            return View(cs);
        }

        [HttpGet]
        public async Task<IActionResult> EditEmployee(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:44320/api/Default/" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonEmployee = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<Class1>(jsonEmployee);

                return View(values);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> EditEmployee(Class1 p)
        {
            var httpClient = new HttpClient();
            var jsonEmployee = JsonConvert.SerializeObject(p);
            var content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var resposeMessage = await httpClient.PutAsync("https://localhost:44320/api/Default", content);
            //response = apiye bağlı olan isteği gerçekleştiriyoruz
            if (resposeMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(p);
        }


        public class Class1
        {
            public int EmployeeID { get; set; }
            public string EmployeName { get; set; }
        }
    }
}
