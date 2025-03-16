using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AtasAPI.Models
{
    public class Workshop
    {
        public int Id { get; set; }

        [Required]
        public string? Nome { get; set; }
        public DateTime DataRealizacao { get; set; }
        public string Descricao { get; set; } = string.Empty;

        [JsonIgnore]
        public ICollection<Presenca>? ColaboradorWorkshops { get; set; }
    }
}
