using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AtasAPI.Models
{
    public class Presenca
    {
        public int Id { get; set; }

        [ForeignKey("Colaborador")]
        public int ColaboradorId { get; set; }
        
        [JsonIgnore]
        public Colaborador? Colaborador { get; set; }

        [ForeignKey("Workshop")]
        public int WorkshopId { get; set; }

        [JsonIgnore]
        public Workshop? Workshop { get; set; }
    }
}
