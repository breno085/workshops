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
            var colaboradores = _context.Colaboradores.ToList();

            if (colaboradores is null)
                return NotFound("Colaboradores não encontrados");

            return Ok(colaboradores);
        }

        [HttpGet("{id:int}", Name = "ObterColaborador")]
        public ActionResult<Colaborador> Get(int id)
        {
            var colaborador = _context.Colaboradores.FirstOrDefault(c => c.Id == id);

            if (colaborador is null)
                return NotFound("Colaborador não encontrado");

            return Ok(colaborador);
        }

        //Obtém os Workshops que um colaborador já participou
        [HttpGet("{id:int}/workshops")]
        public ActionResult GetWorkshopsPorColaborador(int id)
        {
            var workshops = _context.Presencas
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

            return Ok(workshops);
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



        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Colaborador colaborador)
        {
            if (id != colaborador.Id)
                return BadRequest();

            //OBS: Fazendo dessa forma deve-se sempre modificar todas as propriedades da entidade no body do request
            _context.Entry(colaborador).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(colaborador);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var colaborador = _context.Colaboradores.FirstOrDefault(c => c.Id == id);
            //Outra forma:
            //var workshop = _context.Workshops.Find(id);

            if (colaborador is null)
                return NotFound("Colaborador não encontrado");

            _context.Remove(colaborador);
            _context.SaveChanges();

            return Ok();
        }
    }
}
