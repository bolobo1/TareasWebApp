using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TareasWebApp.Models
{
    public class SPTareaListarIdCLS
    {
        public int TAREAS_ID { get; set; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "La Descripción de la Tarea es requerido")]
        [StringLength(254, ErrorMessage = "Ha superado el tamaño maximo de escritura de la Decripcion de Tarea")]
        public string TAREAS_DESCRIPCION { get; set; }
        public string TAREAS_ESTADO { get; set; }
        public string TAREAS_PRIORIDAD { get; set; }

        [Required(ErrorMessage = "Fecha de Inicio es requerida")]
        [DataType(DataType.Date, ErrorMessage = "Fecha de Inicio invalida.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime TAREAS_FECHA_INICIO { get; set; }

        [Required(ErrorMessage = "Fecha de Inicio es requerida")]
        [DataType(DataType.Date, ErrorMessage = "Fecha de Inicio invalida.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime TAREA_FECHA_FIN { get; set; }

        [Required(ErrorMessage = "La Nota de la Tarea es requerido")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Notas")]
        [StringLength(254, ErrorMessage = "Ha superado el tamaño maximo de escritura de la Decripcion de Tarea")]
        public string TAREAS_NOTAS { get; set; }

        [Required(ErrorMessage = "El Colaborador de la Tarea es requerido")]
        [Display(Name = "Colaborador")]
        public int COLABORADOR_ID { get; set; }
    }
}
