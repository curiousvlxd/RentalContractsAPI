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
    public class EquipmentPlacementContractController : ControllerBase
    {
        private readonly RentalContractsContext _context;

        public EquipmentPlacementContractController(RentalContractsContext context)
        {
            _context = context;
        }

        // GET: api/EquipmentPlacementContract
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipmentPlacementContract>>> GetEquipmentPlacementContracts()
        {
          if (_context.EquipmentPlacementContracts == null)
          {
              return NotFound();
          }
          return await _context.EquipmentPlacementContracts.ToListAsync();
        }

        // GET: api/EquipmentPlacementContract/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EquipmentPlacementContract>> GetEquipmentPlacementContract(int id)
        {
          if (_context.EquipmentPlacementContracts == null)
          {
              return NotFound();
          }
          var equipmentPlacementContract = await _context.EquipmentPlacementContracts.FindAsync(id);

            if (equipmentPlacementContract == null)
            {
                return NotFound();
            }

            return equipmentPlacementContract;
        }

        // PUT: api/EquipmentPlacementContract/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipmentPlacementContract(int id, EquipmentPlacementContract equipmentPlacementContract)
        {
            if (id != equipmentPlacementContract.ContractId)
            {
                return BadRequest();
            }

            _context.Entry(equipmentPlacementContract).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipmentPlacementContractExists(id))
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

        // POST: api/EquipmentPlacementContract
        [HttpPost]
        public async Task<ActionResult<EquipmentPlacementContract>> PostEquipmentPlacementContract(int productionPremisesCode, int technologyEquipmentTypeCode, int numOfUnits)
        {
            if (productionPremisesCode == 0 || technologyEquipmentTypeCode == 0 || numOfUnits == 0)
            {
                return BadRequest("Please enter all the required fields");
            }
            
            if (_context.Find<ProductionPremise>(productionPremisesCode) == null)
            {
                return BadRequest("Production Premises Code does not exist");
            }
            if (_context.Find<TechnologyEquipmentType>(technologyEquipmentTypeCode) == null)
            {
                return BadRequest("Technology Equipment Type Code does not exist");
            }
            if (_context.EquipmentPlacementContracts.Any(e => e.ProductionPremisesCode == productionPremisesCode && e.TechnologyEquipmentTypeCode == technologyEquipmentTypeCode))
            {
                return BadRequest("Equipment Placement Contract already exists");
            }
            var totalArea = numOfUnits * _context.Find<TechnologyEquipmentType>(technologyEquipmentTypeCode).Area;
            if (totalArea > _context.Find<ProductionPremise>(productionPremisesCode).RegulatoryArea)
            {
                return BadRequest("Total area of the equipment is greater than the area of the production premises");
            }

            var equipmentPlacementContract = new EquipmentPlacementContract
            {   
                ContractId = _context.EquipmentPlacementContracts.Max(e => e.ContractId) + 1,
                ProductionPremisesCode = productionPremisesCode,
                TechnologyEquipmentTypeCode = technologyEquipmentTypeCode,
                NumOfUnits = numOfUnits
            };
            
            _context.EquipmentPlacementContracts.Add(equipmentPlacementContract);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEquipmentPlacementContract", new { id = equipmentPlacementContract.ContractId }, equipmentPlacementContract);
        }

        // DELETE: api/EquipmentPlacementContract/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipmentPlacementContract(int id)
        {
            if (_context.EquipmentPlacementContracts == null)
            {
                return NotFound();
            }
            var equipmentPlacementContract = await _context.EquipmentPlacementContracts.FindAsync(id);
            if (equipmentPlacementContract == null)
            {
                return NotFound();
            }

            _context.EquipmentPlacementContracts.Remove(equipmentPlacementContract);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EquipmentPlacementContractExists(int id)
        {
            return (_context.EquipmentPlacementContracts?.Any(e => e.ContractId == id)).GetValueOrDefault();
        }
    }
}
