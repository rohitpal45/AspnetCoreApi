using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using democoreapi.Data.Context;
using democoreapi.Data.Model;

namespace democoreapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblBookListsController : ControllerBase
    {
        private readonly CompanyContext _context;

        public TblBookListsController(CompanyContext context)
        {
            _context = context;
        }

        // GET: api/TblBookLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblBookList>>> GetTblBookList()
        {
            return await _context.TblBookList.ToListAsync();
        }

        // GET: api/TblBookLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblBookList>> GetTblBookList(int id)
        {
            var tblBookList = await _context.TblBookList.FindAsync(id);

            if (tblBookList == null)
            {
                return NotFound();
            }

            return tblBookList;
        }

        // PUT: api/TblBookLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblBookList(int id, TblBookList tblBookList)
        {
            if (id != tblBookList.Bid)
            {
                return BadRequest();
            }

            _context.Entry(tblBookList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblBookListExists(id))
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

        // POST: api/TblBookLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblBookList>> PostTblBookList(TblBookList tblBookList)
        {
            _context.TblBookList.Add(tblBookList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblBookList", new { id = tblBookList.Bid }, tblBookList);
        }

        // DELETE: api/TblBookLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblBookList(int id)
        {
            var tblBookList = await _context.TblBookList.FindAsync(id);
            if (tblBookList == null)
            {
                return NotFound();
            }

            _context.TblBookList.Remove(tblBookList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblBookListExists(int id)
        {
            return _context.TblBookList.Any(e => e.Bid == id);
        }
    }
}
