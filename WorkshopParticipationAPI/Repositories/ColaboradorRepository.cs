using AtasAPI.Data.Context;
using AtasAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace WorkshopParticipationAPI.Repositories
{
    public class ColaboradorRepository : IColaboradorRepository
    {
        private readonly AppDbContext _context;

        public ColaboradorRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Colaborador> GetAll()
        {
            return _context.Colaboradores.AsNoTracking().ToList();
        }

        public Colaborador GetById(int id)
        {
            return _context.Colaboradores.AsNoTracking().FirstOrDefault(c => c.Id == id)!;
        }

        public IEnumerable<AtasAPI.Models.Workshop> GetWorkshopsPorColaborador(int id)
        {
            return _context.Presencas
                    .AsNoTracking()
                    .Where(p => p.ColaboradorId == id)
                    .Select(p => p.Workshop)
                    .Distinct()
                    .ToList()!;
        }
        public void Add(Colaborador colaborador)
        {
            _context.Colaboradores.Add(colaborador);
            _context.SaveChanges();
        }

        public void Update(Colaborador colaborador)
        {
            _context.Entry(colaborador).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Colaborador colaborador)
        {
            _context.Colaboradores.Remove(colaborador);
            _context.SaveChanges();
        }
    }
}
