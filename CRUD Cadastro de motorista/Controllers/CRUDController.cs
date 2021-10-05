using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Net.Http;
using CRUD_Cadastro_de_motorista.Models;

namespace CRUD_Cadastro_de_motorista.Controllers
{
    public class CRUDController : Controller
    {
        
        // GET: CRUD
        public ActionResult Index()
        {
            IEnumerable<Newmotorista> motobj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44305/api/Motorista");

            var consumeapi = hc.GetAsync("Motorista");
            consumeapi.Wait();

            var reeddata = consumeapi.Result;
            if (reeddata.IsSuccessStatusCode)
            {
                var displaydata = reeddata.Content.ReadAsAsync<IList<Newmotorista>>();
                displaydata.Wait();

                motobj = displaydata.Result;
            }
            return View(motobj);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Newmotorista motinset)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress=new Uri("https://localhost:44305/api/Motorista");

            var insertcod = hc.PostAsJsonAsync<Newmotorista>("Motorista", motinset);
            insertcod.Wait();

            var savedate = insertcod.Result;
            if (savedate.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Create");
        }

        public ActionResult Details(int id)
        {
            Motorista motobj = null;

            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44305/api/");

            var consumeapi = hc.GetAsync("Motorista?id="+ id.ToString());
            consumeapi.Wait();

            var reeddata = consumeapi.Result;
            if (reeddata.IsSuccessStatusCode)
            {
                var displaydata = reeddata.Content.ReadAsAsync<Motorista>();
                displaydata.Wait();

                motobj = displaydata.Result;
            }
            return View(motobj);
        }

        public ActionResult Edit(int id)
        {
            Motorista motobj = null;

            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44305/api/");

            var consumeapi = hc.GetAsync("Motorista?id=" + id.ToString());
            consumeapi.Wait();

            var reeddata = consumeapi.Result;
            if (reeddata.IsSuccessStatusCode)
            {
                var displaydata = reeddata.Content.ReadAsAsync<Motorista>();
                displaydata.Wait();
                motobj = displaydata.Result;
            }
            return View(motobj);
        }

        [HttpPost]
        public ActionResult Edit(Motorista ec)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44305/api/Motorista");

            var insertcod = hc.PutAsJsonAsync<Motorista>("Motorista", ec);
            insertcod.Wait();

            var savedate = insertcod.Result;
            if (savedate.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.massage = "Motorista não atualizade com sucesso!";
            }
            return View(ec);

        }

        public ActionResult Delete(int id)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44305/api/Motorista");

            var delrecord = hc.DeleteAsync("Motorista/" + id.ToString());
            delrecord.Wait();

            var desplay = delrecord.Result;
            if (desplay.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Index");
        }
    }
}