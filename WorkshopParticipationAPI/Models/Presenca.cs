namespace AtasAPI.Models
{
    public class Presenca
    {
        public int Id { get; set; }
        
        public int ColaboradorId { get; set; }
        public Colaborador? Colaborador { get; set; }

        public int WorkshopId { get; set; }
        public Workshop? Workshop { get; set; }
    }
}
