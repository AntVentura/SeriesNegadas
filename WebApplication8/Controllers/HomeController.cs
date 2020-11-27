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


        public async Task<ActionResult> Index()
        {
            string fechaHasta = DateTime.UtcNow.ToString("yyyy-MM-dd");
            string fechaDesde = DateTime.Today.AddMonths(-6).ToString("yyyy-MM-dd");
            int consultasYreportes = 3;

            string _URL = $"http://apisitelocal.indotel.net.do/SeriesNegadas/ConsultarSeriesReportadasPrestadora?fechaDesde={fechaDesde}&fechaHasta={fechaHasta}&accion={consultasYreportes}";
            var httpCiente = new HttpClient();
            var json = await httpCiente.GetStringAsync(_URL);

            ConsultaViewModel lista = new ConsultaViewModel();
            lista.items = JsonConvert.DeserializeObject<List<items>>(json);
            lista.Accion = consultasYreportes; 
            lista.fechaDesde = Convert.ToDateTime(fechaDesde);
            lista.fechaHasta = Convert.ToDateTime(fechaHasta);
           
            return View(lista);
        }

        [HttpPost]
        public async Task<ActionResult> Index(ConsultaViewModel consulta)
        {
            try {

                int consultasYreportes = 3;

                string _URL = $"http://apisitelocal.indotel.net.do/SeriesNegadas/ConsultarSeriesReportadasPrestadora?fechaDesde={consulta.fechaDesde.ToString("yyyy-MM-dd")}&fechaHasta={consulta.fechaHasta.ToString("yyyy-MM-dd")}&accion={consulta.Accion}";
                var httpCliente = new HttpClient();
                var json = await httpCliente.GetStringAsync(_URL);

                ConsultaViewModel lista = new ConsultaViewModel();
                lista.items = JsonConvert.DeserializeObject<List<items>>(json);
                lista.Accion = consulta.Accion != 0 ? consulta.Accion : consultasYreportes;
                lista.fechaDesde = consulta.fechaDesde;
                lista.fechaHasta = consulta.fechaHasta;
     
            return View(lista);

            } catch { return RedirectToAction("/Index"); }
            

        }

    }
}