using AtasAPI.Data.Context;
using AtasAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WorkshopParticipationAPI.Controllers
{
    [Route("api/workshops")]
    [ApiController]
    public class WorkshopsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public WorkshopsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Workshop>> Get()
        {
            var workshops = _context.Workshops.ToList();

            if (workshops is null)
                return NotFound("Workshops não encontrados");

            return Ok(workshops);
        }

        [HttpGet("{id:int}", Name = "ObterWorkshop")]
        public ActionResult<Workshop> Get(int id)
        {
            var workshop = _context.Workshops.FirstOrDefault(c => c.Id == id);

            if (workshop is null)
                return NotFound("Workshop não encontrado");

            return Ok(workshop);
        }

        [HttpPost]
        public ActionResult Post(Workshop workshop)
        {
            if (workshop is null)
                return BadRequest();

            _context.Workshops.Add(workshop);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterWorkshop", new { id = workshop.Id, workshop });
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Workshop workshop)
        {
            if (id != workshop.Id)
                return BadRequest();

            _context.Entry(workshop).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(workshop);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var workshop = _context.Workshops.FirstOrDefault(c => c.Id == id);
            //var workshop = _context.Workshops.Find(id); - outra forma

            if (workshop is null)
                return NotFound("workshop não encontrado");

            _context.Remove(workshop);
            _context.SaveChanges();

            return Ok();
        }
    }
}
