using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication8.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication8.Models
{
    public class ConsultaViewModel
    {
        public IEnumerable<items> items { get; set; }

        public int Accion { get; set; }

        [DataType(DataType.Date)]
        [Required]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime fechaDesde { get; set; }

        [DataType(DataType.Date)]
        [Required]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime fechaHasta { get; set; }
    }

}