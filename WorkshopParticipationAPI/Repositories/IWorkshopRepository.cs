using AtasAPI.Models;

namespace WorkshopParticipationAPI.Repositories
{
    public interface IWorkshopRepository
    {
        IEnumerable<Workshop> GetAll();
        Workshop GetById(int id);
        void Add(Workshop workshop);
        void Update(Workshop workshop);
        void Delete(Workshop workshop);
        IEnumerable<Colaborador> GetColaboradoresPorWorkshop(int id);
    }
}
