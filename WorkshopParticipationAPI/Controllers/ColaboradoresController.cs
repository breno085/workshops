using AtasAPI.Data.Context;
using AtasAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkshopParticipationAPI.Repositories;

namespace WorkshopParticipationAPI.Controllers
{
    [Route("api/colaboradores")]
    [ApiController]
    public class ColaboradoresController : ControllerBase
    {
        private readonly IColaboradorRepository _colaboradorRepository;

        public ColaboradoresController(IColaboradorRepository colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Colaborador>> GetAll()
        {
            var colaboradores = _colaboradorRepository.GetAll();

            if (colaboradores is null)
                return NotFound("Colaboradores não encontrados");

            return Ok(colaboradores);
        }

        [HttpGet("{id:int}", Name = "ObterColaborador")]
        public ActionResult<Colaborador> GetById(int id)
        {
            var colaborador = _colaboradorRepository.GetById(id);

            if (colaborador is null)
                return NotFound("Colaborador não encontrado");

            return Ok(colaborador);
        }

        [HttpGet("{id:int}/workshops")]
        public ActionResult GetWorkshopsPorColaborador(int id)
        {
            var workshopsPorColaborador = _colaboradorRepository.GetWorkshopsPorColaborador(id);

            if (!workshopsPorColaborador.Any())
                return NotFound();

            return Ok(workshopsPorColaborador);
        }

        [HttpPost]
        public ActionResult Post(Colaborador colaborador)
        {
            if (colaborador is null)
                return BadRequest();

            _colaboradorRepository.Add(colaborador);

            return new CreatedAtRouteResult("ObterColaborador", new { id = colaborador.Id, colaborador });
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Colaborador colaborador)
        {
            if (id != colaborador.Id)
                return BadRequest();

            _colaboradorRepository.Update(colaborador);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var colaborador = _colaboradorRepository.GetById(id);

            if (colaborador is null)
                return NotFound("Colaborador não encontrado");

            _colaboradorRepository.Delete(colaborador);

            return Ok();
        }
    }
}
