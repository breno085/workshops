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

            _context.Entry(colaborador).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(colaborador);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var colaborador = _context.Colaboradores.FirstOrDefault(c => c.Id == id);

            if (colaborador is null)
                return NotFound("Colaborador não encontrado");

            _context.Remove(colaborador);
            _context.SaveChanges();

            return Ok();
        }
    }
}
