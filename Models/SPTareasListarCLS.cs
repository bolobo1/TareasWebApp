

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TareasWebApp.Models
{
	public class SPTareasListarCLS
	{
		public int TAREAS_ID { get; set; }

        [Display(Name = "Descripción")]
        public string TAREAS_DESCRIPCION { get; set; }

        [Display(Name = "Estado")]
        public string TAREAS_ESTADO { get; set; }

        [Display(Name = "Prioridad")]
        public string TAREAS_PRIORIDAD { get; set; }

        [Display(Name = "Fecha inicio")]
        [DataType(DataType.Date, ErrorMessage = "The Date field is not valid.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime TAREAS_FECHA_INICIO { get; set; }

        [Display(Name = "Fecha fin")]
        [DataType(DataType.Date, ErrorMessage = "The Date field is not valid.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime TAREA_FECHA_FIN { get; set; }

        [Display(Name = "Notas")]
        public string TAREAS_NOTAS { get; set; }
        public int COLABORADOR_ID { get; set; }

        [Display(Name = "Colaborador")]
        public string NOMBRE { get; set; }
	}
}
