using AtasAPI.Data.Context;
using AtasAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace WorkshopParticipationAPI.Repositories
{
    public class WorkshopRepository : IWorkshopRepository
    {
        private readonly AppDbContext _context;

        public WorkshopRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Workshop> GetAll()
        {
            return _context.Workshops.AsNoTracking().ToList();
        }

        public Workshop GetById(int id)
        {
            return _context.Workshops.AsNoTracking().FirstOrDefault(w => w.Id == id)!;
        }

        public void Add(Workshop workshop)
        {
            _context.Workshops.Add(workshop);
            _context.SaveChanges();
        }

        public void Update(Workshop workshop)
        {
            _context.Entry(workshop).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Workshop workshop)
        {
            var presencas = _context.Presencas.Where(p => p.WorkshopId == workshop.Id).ToList();

            _context.Presencas.RemoveRange(presencas);
            _context.SaveChanges();

            _context.Workshops.Remove(workshop);
            _context.SaveChanges();
        }

        public IEnumerable<Colaborador> GetColaboradoresPorWorkshop(int id)
        {
            return _context.Presencas
                .AsNoTracking()
                .Where(p => p.WorkshopId == id)
                .Select(p => p.Colaborador)
                .Distinct()
                .ToList()!;
        }
    }
}
