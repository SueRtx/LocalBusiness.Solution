using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LocalApi.Models;

namespace LocalApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BusinessesController : ControllerBase
  {
    private readonly LocalApiContext _db;

    public BusinessesController(LocalApiContext db)
    {
      _db = db;
    }

  // GET: api/Businesses
    [HttpGet]
    public async Task<List<Business>> Get(string name, string description, string location)
    {
      IQueryable<Business> query = _db.Businesses.AsQueryable();

      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);

      }
      if (description != null)
      {
        query = query.Where(entry => entry.Description == description);
      }

      if (location != null)
      {
        query = query.Where(entry => entry.Location == location);
      }

      return await query.ToListAsync();
    }

    // GET: api/Businesses/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Business>> GetBusiness(int id)
    {
        var business = await _db.Businesses.FindAsync(id);

        if (business == null)
        {
            return NotFound();
        }

        return business;
    }

    // PUT: api/Businesses/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Business business)
    {
      if (id != business.BusinessId)
      {
        return BadRequest();
      }

      _db.Entry(business).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!BusinessExists(id))
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

    // POST: api/Businesses
    [HttpPost]
    public async Task<ActionResult<Business>> Post(Business business)
    {
      _db.Businesses.Add(business);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetBusiness), new { id = business.BusinessId }, business);
    }

    // DELETE: api/Businesses/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBusiness(int id)
    {
      var business = await _db.Businesses.FindAsync(id);
      if (business == null)
      {
        return NotFound();
      }

      _db.Businesses.Remove(business);
      await _db.SaveChangesAsync();

      return NoContent();
    }



  }
}