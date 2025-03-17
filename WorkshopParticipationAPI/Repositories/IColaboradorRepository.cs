using AtasAPI.Models;

namespace WorkshopParticipationAPI.Repositories
{
    public interface IColaboradorRepository
    {
        IEnumerable<Colaborador> GetAll();
        Colaborador GetById(int id);
        IEnumerable<Workshop> GetWorkshopsPorColaborador(int id);
        void Add(Colaborador colaborador);
        void Update(Colaborador colaborador);
        void Delete(Colaborador colaborador);
    }
}
