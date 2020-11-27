using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using WebApplication8.Models;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;

namespace WebApplication8.Controllers
{
    public class HomeController : Controller
    {
        Reportes _r = new Reportes();

        public ActionResult Index()
        {
            var lista = _r.GET();

            return View(lista);
        }

        [HttpPost]
        public ActionResult Index(ConsultaViewModel consulta)
        {
            var lista = _r.Consulta(consulta);
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-ES");
       
            lista.Accion = consulta.Accion;
            lista.fechaDesde = consulta.fechaDesde;
            lista.fechaHasta = consulta.fechaHasta;
            return View(lista);
        }

    }
}