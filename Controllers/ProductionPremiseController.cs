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
    public class ProductionPremiseController : ControllerBase
    {
        private readonly RentalContractsContext _context;

        public ProductionPremiseController(RentalContractsContext context)
        {
            _context = context;
        }

        // GET: api/ProductionPremise
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductionPremise>>> GetProductionPremises()
        {
            return await _context.ProductionPremises.ToListAsync();
        }
        
        // GET: api/ProductionPremise/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductionPremise>> GetProductionPremise(int id)
        {
            var productionPremise = await _context.ProductionPremises.FindAsync(id);

            if (productionPremise == null)
            {
                return NotFound();
            }

            return productionPremise;
        }
        
        // PUT: api/ProductionPremise/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductionPremise(int id, ProductionPremise productionPremise)
        {
            if (id != productionPremise.Code)
            {
                return BadRequest();
            }

            _context.Entry(productionPremise).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductionPremiseExists(id))
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
        
        // POST: api/ProductionPremise
        [HttpPost]
        public async Task<ActionResult<ProductionPremise>> PostProductionPremise(string Name, int RegulatoryArea )
        {   
            if (Name == null || RegulatoryArea == null || RegulatoryArea == 0)
            {
                return BadRequest();
            }

            var productionPremise = new ProductionPremise
            {   
                Code = _context.ProductionPremises.Max(e => e.Code) + 1,
                Name = Name,
                RegulatoryArea = RegulatoryArea
            };
            
            _context.ProductionPremises.Add(productionPremise);
            await _context.SaveChangesAsync();
            
            return CreatedAtAction("GetProductionPremise", new { id = productionPremise.Code }, productionPremise);
        }
        
        // DELETE: api/ProductionPremise/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductionPremise(int id)
        {
            var productionPremise = await _context.ProductionPremises.FindAsync(id);
            if (productionPremise == null)
            {
                return NotFound();
            }

            _context.ProductionPremises.Remove(productionPremise);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductionPremiseExists(int id)
        {
            return _context.ProductionPremises.Any(e => e.Code == id);
        }
    }
}
