
using System.ComponentModel.DataAnnotations;

namespace AtividadeMVC.Models
{
    public class BuscarEventoViewModel
    {
        [Display(Name = "Nome do Evento")]
        public string? NomeBusca { get; set; }

        [Display(Name = "Local")]
        public string? LocalBusca { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "A partir da data")]
        public DateTime? DataInicial { get; set; }

        public List<Evento> Resultados { get; set; } = new List<Evento>();
    }
}