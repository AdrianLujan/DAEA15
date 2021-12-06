using Newtonsoft.Json;
using Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WEBSiteTecsup.Models;

namespace WEBSiteTecsup.Controllers
{
    public class AnimesController : Controller
    {
        // GET: Animes
        public async Task<ActionResult> Index()
        {
            List<AnimeModel> model = new List<AnimeModel>();
            var client = new HttpClient();
            var urlBase = "https://localhost:44315";
            client.BaseAddress = new Uri(urlBase);
            var url = string.Concat(urlBase, "/Api", "/Animes", "/GetAnimes");


            var response = client.GetAsync(url).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                //De JSON a Response
                var anime = JsonConvert.DeserializeObject<List<AnimeModel>>(result);

                //De Response a Model
                model = anime;
            }
            return View(model);
        }

        // GET: Animes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Animes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Animes/Create
        [HttpPost]
        public async Task<ActionResult> Create(AnimeModel model)
        {
            try
            {
                // TODO: Add insert logic here

                var request = JsonConvert.SerializeObject(model);
                var content = new StringContent(request, Encoding.UTF8, "application/json");

                var client = new HttpClient();
                var urlBase = "https://localhost:44315";
                client.BaseAddress = new Uri(urlBase);
                var url = string.Concat(urlBase, "/Api", "/Animes", "/PostAnime");

                var response = client.PostAsync(url, content).Result;

                if (response.StatusCode == HttpStatusCode.Created)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    //Si sale algo con error, puedes enviar una alerta.
                    //var exito = JsonConvert.DeserializeObject<bool>(result);

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Animes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Animes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Animes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Animes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
