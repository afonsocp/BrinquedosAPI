using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BrinquedosAPI.Data;
using BrinquedosAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrinquedosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrinquedosController : ControllerBase
    {
        private readonly BrinquedosContext _context;

        public BrinquedosController(BrinquedosContext context)
        {
            _context = context;
        }

        // GET: api/Brinquedos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brinquedo>>> GetBrinquedos()
        {
            var brinquedos = await _context.TDS_TB_Brinquedos.ToListAsync();
            
            foreach (var brinquedo in brinquedos)
            {
                AddLinksToResource(brinquedo);
            }
            
            return brinquedos;
        }

        // GET: api/Brinquedos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Brinquedo>> GetBrinquedo(int id)
        {
            var brinquedo = await _context.TDS_TB_Brinquedos.FindAsync(id);

            if (brinquedo == null)
            {
                return NotFound();
            }

            AddLinksToResource(brinquedo);
            return brinquedo;
        }

        // POST: api/Brinquedos
        [HttpPost]
        public async Task<ActionResult<Brinquedo>> PostBrinquedo(Brinquedo brinquedo)
        {
            _context.TDS_TB_Brinquedos.Add(brinquedo);
            await _context.SaveChangesAsync();

            AddLinksToResource(brinquedo);
            return CreatedAtAction("GetBrinquedo", new { id = brinquedo.Id_brinquedo }, brinquedo);
        }

        // PUT: api/Brinquedos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBrinquedo(int id, Brinquedo brinquedo)
        {
            if (id != brinquedo.Id_brinquedo)
            {
                return BadRequest();
            }

            _context.Entry(brinquedo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrinquedoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Brinquedos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrinquedo(int id)
        {
            var brinquedo = await _context.TDS_TB_Brinquedos.FindAsync(id);
            if (brinquedo == null)
            {
                return NotFound();
            }

            _context.TDS_TB_Brinquedos.Remove(brinquedo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private void AddLinksToResource(Brinquedo brinquedo)
        {
            var baseUrl = $"{Request.Scheme}://{Request.Host}/api/brinquedos";
            
            // Link para si mesmo (self)
            brinquedo.AddLink($"{baseUrl}/{brinquedo.Id_brinquedo}", "self", "GET");
            
            // Link para atualizar
            brinquedo.AddLink($"{baseUrl}/{brinquedo.Id_brinquedo}", "update", "PUT");
            
            // Link para deletar
            brinquedo.AddLink($"{baseUrl}/{brinquedo.Id_brinquedo}", "delete", "DELETE");
            
            // Link para listar todos
            brinquedo.AddLink($"{baseUrl}", "all", "GET");
            
            // Link para criar novo
            brinquedo.AddLink($"{baseUrl}", "create", "POST");
        }

        private bool BrinquedoExists(int id)
        {
            return _context.TDS_TB_Brinquedos.Any(e => e.Id_brinquedo == id);
        }
    }
}