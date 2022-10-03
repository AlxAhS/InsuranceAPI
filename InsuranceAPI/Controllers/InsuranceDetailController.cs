using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InsuranceAPI.Models;

namespace InsuranceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceDetailController : ControllerBase
    {
        private readonly InsuranceDetailContext _context;

        public InsuranceDetailController(InsuranceDetailContext context)
        {
            _context = context;
        }

        // GET: api/InsuranceDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InsuranceDetail>>> GetInsuranceDetails()
        {
            return await _context.InsuranceDetails.ToListAsync();
        }

        // GET: api/InsuranceDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InsuranceDetail>> GetInsuranceDetail(int id)
        {
            var insuranceDetail = await _context.InsuranceDetails.FindAsync(id);

            if (insuranceDetail == null)
            {
                return NotFound();
            }

            return insuranceDetail;
        }

        // PUT: api/InsuranceDetail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInsuranceDetail(int id, InsuranceDetail insuranceDetail)
        {
            if (id != insuranceDetail.UserId)
            {
                return BadRequest();
            }

            _context.Entry(insuranceDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InsuranceDetailExists(id))
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

        // POST: api/InsuranceDetail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InsuranceDetail>> PostInsuranceDetail(InsuranceDetail insuranceDetail)
        {
            _context.InsuranceDetails.Add(insuranceDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInsuranceDetail", new { id = insuranceDetail.UserId }, insuranceDetail);
        }

        // DELETE: api/InsuranceDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInsuranceDetail(int id)
        {
            var insuranceDetail = await _context.InsuranceDetails.FindAsync(id);
            if (insuranceDetail == null)
            {
                return NotFound();
            }

            _context.InsuranceDetails.Remove(insuranceDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InsuranceDetailExists(int id)
        {
            return _context.InsuranceDetails.Any(e => e.UserId == id);
        }
    }
}
