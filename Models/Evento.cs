using System.ComponentModel.DataAnnotations;

namespace AtividadeMVC.Models
{
    public class Evento
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do evento é obrigatório.")]
        [StringLength(80, MinimumLength = 5, ErrorMessage = "O nome deve ter entre 5 e 80 caracteres.")]
        [Display(Name = "Nome do Evento")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        [MinLength(10, ErrorMessage = "A descrição deve ter no mínimo 10 caracteres.")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = "O local é obrigatório.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O local deve ter entre 3 e 100 caracteres.")]
        public string Local { get; set; } = string.Empty;

        [Required(ErrorMessage = "A data do evento é obrigatória.")]
        [DataType(DataType.DateTime)]
       [Display(Name = "Data e Hora")]
        public DateTime DataEvento { get; set; }

        [Required(ErrorMessage = "A quantidade de vagas é obrigatória.")]
        [Range(1, 1000, ErrorMessage = "A quantidade de vagas deve ser entre 1 e 1000.")]
        [Display(Name = "Quantidade de Vagas")]
        public int QuantidadeVagas { get; set; }

        [Required(ErrorMessage = "O valor do ingresso é obrigatório.")]
        [Range(0, 100000, ErrorMessage = "O valor não pode ser negativo.")]
        [DataType(DataType.Currency)]
        [Display(Name = "Valor do Ingresso")]
        public decimal ValorIngresso { get; set; }
    }
}