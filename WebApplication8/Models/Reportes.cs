using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication8.Models;

namespace WebApplication8.Models
{
    public class Reportes
    {
        public async Task<ActionResult> GetReporte( ConsultaViewModel consulta )
        {
            string _URL = $"apisitelocal.indotel.net.do/SeriesNegadas/ConsultarSeriesReportadasPrestadora?fechaDesde={consulta.fechaDesde}1&fechaHasta={consulta.fechaDesde}&accion={consulta.Accion}";
            var httpCiente = new HttpClient();

            var json = await httpCiente.GetStringAsync(_URL);

            return null;
        }





        ApiConsultaEntities db = new ApiConsultaEntities();

       public ConsultaViewModel GET()
        {
            ConsultaViewModel consultavm = new ConsultaViewModel();

           consultavm.items = db.Database.SqlQuery<items>("select p.Nombre as Prestadora ,COUNT(p.Nombre) as SeriesNegadas from Prestadoras p inner join Reportes r on p.Id = r.IdPrestadora group by p.Nombre").ToList();

            return consultavm;
        }

        public ConsultaViewModel Consulta(ConsultaViewModel consulta)
        {
            DateTime fechaDesde = consulta.fechaDesde;
            DateTime fechaHasta = consulta.fechaHasta;

         
            ConsultaViewModel consultavm = new ConsultaViewModel();

            consultavm.items = db.Database.SqlQuery<items>("select p.Nombre as Prestadora ,COUNT(p.Nombre) as SeriesNegadas from Prestadoras p inner join Reportes r on p.Id = r.IdPrestadora where r.Fecha between '"+ fechaDesde + "' AND '"+ fechaHasta + "' group by p.Nombre").ToList();

            return consultavm;
        }
    }
}