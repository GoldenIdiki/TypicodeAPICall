using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TypicodeCall.Core.Models;

namespace TypicodeCall.Core.Controllers
{
    public class TypicodeController : Controller
    {
        static readonly HttpClient client = new HttpClient();
        public TypicodeController()
        {
            client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        

        // GET: TypicodeController
        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            HttpResponseMessage responseMessage = await client.GetAsync("posts");
            if (responseMessage.IsSuccessStatusCode)
            {
                string apiResponse = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<IEnumerable<Post>>(apiResponse);
                return View(result);
            }
            return View();
        }

        // GET: TypicodeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TypicodeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypicodeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TypicodeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TypicodeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TypicodeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TypicodeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
