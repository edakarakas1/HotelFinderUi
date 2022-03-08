using ApiUygulama.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiUygulama.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<Hotel> hotelslist = new List<Hotel>();
            var client = new HttpClient();
            var resposetask = client.GetAsync("https://localhost:44320/api/Hotels");
            var result = resposetask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync();
                var hotel = readTask.Result;
                hotelslist = JsonConvert.DeserializeObject<List<Hotel>>(hotel);
            }
            return View(hotelslist);
        }

        public IActionResult Detay(int id)
        {
            Hotel hotel = new Hotel();
            var client = new HttpClient();
            var responsetask = client.GetAsync("https://localhost:44320/api/Hotels/" + id);
            var result = responsetask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readtask = result.Content.ReadAsStringAsync();
                var hotelresult = readtask.Result;
                hotel = JsonConvert.DeserializeObject<Hotel>(hotelresult);
            }
            return View(hotel);
        }
        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(Hotel h)
        {
            var client = new HttpClient();
            var jsonhotel = JsonConvert.SerializeObject(h);
            StringContent content = new StringContent(jsonhotel, Encoding.UTF8, "application/json");
            var responsemesaj = client.PostAsync("https://localhost:44320/api/Hotels/", content);
            var result = responsemesaj.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(h);
        }

        public IActionResult Sil(int id)
        {
            var client = new HttpClient();
            var responsetask = client.DeleteAsync("https://localhost:44320/api/Hotels/" + id);
            var result = responsetask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return NotFound();
        }
      
        public IActionResult Duzenle(int id)
        {
            var client = new HttpClient();
            var response = client.GetAsync("https://localhost:44320/api/Hotels/" + id);
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var readtask = result.Content.ReadAsStringAsync();
                var okunan = readtask.Result;
                var hotel = JsonConvert.DeserializeObject<Hotel>(okunan);
                return View(hotel);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Duzenle(int id,Hotel h)
        {
            var client = new HttpClient();
            var jsonhotel = JsonConvert.SerializeObject(h);
            StringContent content = new StringContent(jsonhotel,Encoding.UTF8,"application/json");
            var response = client.PutAsync("https://localhost:44320/api/Hotels/", content);
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(h);
        }
    }
}
