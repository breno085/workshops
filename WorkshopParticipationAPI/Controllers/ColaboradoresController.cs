using AtasAPI.Data.Context;
using AtasAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WorkshopParticipationAPI.Controllers
{
    [Route("api/colaboradores")]
    [ApiController]
    public class ColaboradoresController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ColaboradoresController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Colaborador>> Get()
        {
            var colaboradores = _context.Colaboradores.AsNoTracking().ToList();

            if (colaboradores is null)
                return NotFound("Colaboradores não encontrados");

            return Ok(colaboradores);
        }

        [HttpGet("{id:int}", Name = "ObterColaborador")]
        public ActionResult<Colaborador> Get(int id)
        {
            var colaborador = _context.Colaboradores.AsNoTracking().FirstOrDefault(c => c.Id == id);

            if (colaborador is null)
                return NotFound("Colaborador não encontrado");

            return Ok(colaborador);
        }

        [HttpGet("{id:int}/workshops", Name = "ObterPresenca")]
        public ActionResult GetWorkshopsPorColaborador(int id)
        {
            var workshopsPorColaborador = _context.Presencas
                .AsNoTracking()
                .Where(p => p.ColaboradorId == id)
                .Select(p => new
                {
                    p.ColaboradorId,
                    p.WorkshopId,
                    p.Workshop!.Nome,
                    p.Workshop.DataRealizacao,
                    p.Workshop.Descricao
                })
                .Distinct()
                .ToList();

            if (workshopsPorColaborador.Count == 0)
                return NotFound();

            return Ok(workshopsPorColaborador);
        }

        [HttpPost]
        public ActionResult Post(Colaborador colaborador)
        {
            if (colaborador is null)
                return BadRequest();

            _context.Colaboradores.Add(colaborador);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterColaborador", new { id = colaborador.Id, colaborador });
        }

        [HttpPost("workshops")]
        public IActionResult PostColaboradorNoWorkshop(Presenca presenca)
        {
            if (presenca is null)
                return BadRequest();

            bool colaboradorExiste = _context.Colaboradores.Any(c => c.Id == presenca.ColaboradorId);
            if (!colaboradorExiste)
                return NotFound("Colaborador não encontrado");

            bool workshopExiste = _context.Workshops.Any(w => w.Id == presenca.WorkshopId);
            if (!workshopExiste)
                return NotFound("Workshop não encontrado");

            _context.Presencas.Add(presenca);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterPresenca", new { id = presenca.Id, presenca });
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Colaborador colaborador)
        {
            if (id != colaborador.Id)
                return BadRequest();

            //OBS: Fazendo dessa forma deve-se sempre modificar todas as propriedades da entidade no body do request
            _context.Entry(colaborador).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var colaborador = _context.Colaboradores.FirstOrDefault(c => c.Id == id);
            //Outra forma:

            if (colaborador is null)
                return NotFound("Colaborador não encontrado");

            _context.Remove(colaborador);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id:int}/workshops/{workshopId:int}")]
        public ActionResult DeleteColaboradorNumWorkshop(int id, int workshopId)
        {
            var presencaColaboradorWorkshop = _context.Presencas.
                FirstOrDefault(p => p.ColaboradorId == id && p.WorkshopId == workshopId);

            if (presencaColaboradorWorkshop is null)
                return NotFound("Presenca do colaborador no workshop não encontrada");

            _context.Remove(presencaColaboradorWorkshop);
            _context.SaveChanges();

            return Ok();
        }
    }
}
