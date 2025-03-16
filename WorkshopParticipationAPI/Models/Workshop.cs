using System.ComponentModel.DataAnnotations;

namespace AtasAPI.Models
{
    public class Workshop
    {
        public int Id { get; set; }

        [Required]
        public string? Nome { get; set; }
        public DateTime DataRealizacao { get; set; }
        public string Descricao { get; set; } = string.Empty;

        public ICollection<Presenca>? ColaboradorWorkshops { get; set; }
    }
}
