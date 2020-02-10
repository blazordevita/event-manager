using System.Linq;
using backend.Data;
using backend.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using shared.Models;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventiController : ControllerBase
    {
        private readonly ApplicationDbContext db;
    
        public EventiController(ApplicationDbContext db)
        {
            this.db = db;
        }
    
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.db.Eventi.Select(x => new ElementoListaEvento()
            {
                Id = x.Id,
                Nome = x.Nome,
                Localita = x.Localita,
                Data = x.Data
            }).ToList());
        }
    
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = this.db.Eventi
                .Where(x => x.Id == id)
                .Select(x => new DettaglioEvento()
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    Localita = x.Localita,
                    Data = x.Data,
                    Descrizione = x.Descrizione,
                    Note = x.Note
                }).SingleOrDefault();
    
            if(result == null) return NotFound();
            return Ok(result);
        }
    
        [HttpPost]
        public IActionResult Post(DettaglioEvento item)
        {
            if(ModelState.IsValid)
            {
                var entity = new Evento()
                {
                    Id = item.Id,
                    Nome = item.Nome,
                    Localita = item.Localita,
                    Data = item.Data,
                    Descrizione = item.Descrizione,
                    Note = item.Note
                };
                this.db.Add(entity);
                this.db.SaveChanges();
                item.Id = entity.Id;
                return CreatedAtAction(nameof(Get), new { id = entity.Id }, item);
            }
            return BadRequest(ModelState);
        }
    
        [HttpPut("{id}")]
        public IActionResult Put(int id, DettaglioEvento item)
        {
            if(ModelState.IsValid)
            {
                var entity = this.db.Eventi.SingleOrDefault(x => x.Id == id);
                if(entity == null) return NotFound();
                entity.Nome = item.Nome;
                entity.Localita = item.Localita;
                entity.Data = item.Data;
                entity.Descrizione = item.Descrizione;
                entity.Note = item.Note;
                this.db.SaveChanges();
                return NoContent();
            }
            return BadRequest(ModelState);
        }
    
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = this.db.Eventi.SingleOrDefault(x => x.Id == id);
            if(entity == null) return NotFound();
            this.db.Remove(entity);
            this.db.SaveChanges();
            return NoContent();
        }
    }
}