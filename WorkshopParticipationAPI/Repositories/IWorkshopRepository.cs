using AtasAPI.Models;
using Microsoft.EntityFrameworkCore;

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
        IEnumerable<Presenca> GetWorkshopsColaboradores();
        void PostColaboradorNoWorkshop(Presenca presenca);
        Presenca DeleteColaboradorNoWorkshop(int workshopId, int colaboradorId);
    }
}
