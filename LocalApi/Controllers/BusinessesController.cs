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
      IQueryable<Business> query = _db.Businesss.AsQueryable();

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
        query = query.Where(entry => entry.Location >= location);
      }

      return await query.ToListAsync();
    }

    // POST: api/Businesses
    [HttpPost]
    public async Task<ActionResult<Business>> Post(Business business)
    {
      _db.Businesses.Add(business);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetBusiness), new { id = business.BusinessId }, business);
    }



  }
}