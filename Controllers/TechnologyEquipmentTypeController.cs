using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalContractsAPI.Context;
using RentalContractsAPI.Models;

namespace RentalContractsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologyEquipmentTypeController : ControllerBase
    {
        private readonly RentalContractsContext _context;

        public TechnologyEquipmentTypeController(RentalContractsContext context)
        {
            _context = context;
        }
        
        // GET: api/TechnologyEquipmentType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TechnologyEquipmentType>>> GetTechnologyEquipmentTypes()
        {
            return await _context.TechnologyEquipmentTypes.ToListAsync();
        }
        
        // GET: api/TechnologyEquipmentType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TechnologyEquipmentType>> GetTechnologyEquipmentType(int id)
        {
            var technologyEquipmentType = await _context.TechnologyEquipmentTypes.FindAsync(id);
            
            if (technologyEquipmentType == null)
            {
                return NotFound();
            }
            
            return technologyEquipmentType;
        }
        
        // PUT: api/TechnologyEquipmentType/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTechnologyEquipmentType(int id, TechnologyEquipmentType technologyEquipmentType)
        {
            if (id != technologyEquipmentType.Code)
            {
                return BadRequest();
            }
            
            _context.Entry(technologyEquipmentType).State = EntityState.Modified;
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TechnologyEquipmentTypeExists(id))
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
        
        // POST: api/TechnologyEquipmentType
        [HttpPost]
        public async Task<ActionResult<TechnologyEquipmentType>> PostTechnologyEquipmentType(string Name, int Area)
        {
            if (Name == null || Area == null || Area == 0)
            {
                return BadRequest();
            }
            
           var technologyEquipmentType = new TechnologyEquipmentType
           {    
               Code = _context.TechnologyEquipmentTypes.Max(e => e.Code) + 1,
               Name = Name,
               Area = Area
           };
           
           _context.TechnologyEquipmentTypes.Add(technologyEquipmentType);
            await _context.SaveChangesAsync();
            
            return CreatedAtAction("GetTechnologyEquipmentType", new { id = technologyEquipmentType.Code }, technologyEquipmentType);
        }
        
        // DELETE: api/TechnologyEquipmentType/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TechnologyEquipmentType>> DeleteTechnologyEquipmentType(int id)
        {
            var technologyEquipmentType = await _context.TechnologyEquipmentTypes.FindAsync(id);
            if (technologyEquipmentType == null)
            {
                return NotFound();
            }
            
            _context.TechnologyEquipmentTypes.Remove(technologyEquipmentType);
            await _context.SaveChangesAsync();
            
            return technologyEquipmentType;
        }
        
        private bool TechnologyEquipmentTypeExists(int id)
        {
            return _context.TechnologyEquipmentTypes.Any(e => e.Code == id);
        }
    }
}
