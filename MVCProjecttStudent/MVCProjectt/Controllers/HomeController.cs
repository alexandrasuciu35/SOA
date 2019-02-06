using MVCProjectt.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MVCProjectt.Controllers
{
    public class HomeController : Controller
    {
        //static HttpClient client = new HttpClient();

        public async Task<ActionResult> StudentDetails()
        {
            Students Model = new Students();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:4370/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                ViewBag.country = "";
                HttpResponseMessage response = await client.GetAsync("api/Student/getDetails");
                List<string> li;
                if (response.IsSuccessStatusCode)
                {
                    Students obj = new Students();

                    var details = response.Content.ReadAsAsync<IEnumerable<Students>>().Result;
                    return View((object)details);


                }
                else
                {
                    return View();

                }
            }

        }


        public async Task<ActionResult> Update(Students student)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:4370/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //HttpResponseMessage response = await     
                var Result = client.PostAsJsonAsync("api/Student/UpdateDetails", student).Result;
                if (Result.IsSuccessStatusCode == true)
                {
                    return View();

                }
                else
                {
                    return View();
                }
            }
        }

        public async Task<ActionResult> DeleteUser(Students student)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:4370/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //HttpResponseMessage response = await   
                var Result = client.PostAsJsonAsync("api/Student/DeleteStudent", student).Result;
                if (Result.IsSuccessStatusCode == true)
                {
                    return View();

                }
                else
                {
                    return View();
                }
            }
        }
    }
}