using System.ComponentModel.DataAnnotations;

namespace AtasAPI.Models
{
    public class Colaborador
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public ICollection<Presenca>? ColaboradorWorkshops { get; set; }
    }
}
