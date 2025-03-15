using System.ComponentModel.DataAnnotations.Schema;

namespace AtasAPI.Models
{
    public class Presenca
    {
        public int Id { get; set; }

        [ForeignKey("Colaborador")]
        public int ColaboradorId { get; set; }
        public Colaborador? Colaborador { get; set; }

        [ForeignKey("Workshop")]
        public int WorkshopId { get; set; }
        public Workshop? Workshop { get; set; }
    }
}
