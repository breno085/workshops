using AtasAPI.Data.Context;
using AtasAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkshopParticipationAPI.Repositories;

namespace WorkshopParticipationAPI.Controllers
{
    [Route("api/workshops")]
    [ApiController]
    public class WorkshopsController : ControllerBase
    {
        private readonly IWorkshopRepository _workshopRepository;

        public WorkshopsController(IWorkshopRepository workshopRepository)
        {
            _workshopRepository = workshopRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Workshop>> GetAll()
        {
            var workshops = _workshopRepository.GetAll();

            if (workshops is null)
                return NotFound("Workshops não encontrados");

            return Ok(workshops);
        }

        [HttpGet("{id:int}", Name = "ObterWorkshop")]
        public ActionResult<Workshop> GetById(int id)
        {
            var workshop = _workshopRepository.GetById(id);

            if (workshop is null)
                return NotFound("Workshop não encontrado");

            return Ok(workshop);
        }

        [HttpGet("{id:int}/colaboradores")]
        public ActionResult<IEnumerable<Colaborador>> GetColaboradoresPorWorkshop(int id)
        {
            var colaboradores = _workshopRepository.GetColaboradoresPorWorkshop(id);

            if (!colaboradores.Any())
                return NotFound("Nenhum colaborador encontrado para este workshop");

            return Ok(colaboradores);
        }

        [HttpPost]
        public ActionResult Post(Workshop workshop)
        {
            if (workshop is null)
                return BadRequest();

            _workshopRepository.Add(workshop);

            return new CreatedAtRouteResult("ObterWorkshop", new { id = workshop.Id, workshop });
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Workshop workshop)
        {
            if (id != workshop.Id)
                return BadRequest();

            _workshopRepository.Update(workshop);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var workshop = _workshopRepository.GetById(id);

            if (workshop is null)
                return NotFound("workshop não encontrado");

            _workshopRepository.Delete(workshop);

            return Ok();
        }
    }
}
