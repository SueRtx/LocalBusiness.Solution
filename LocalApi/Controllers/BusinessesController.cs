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
  [Produces("application/json")]
  [Route("api/[controller]")]
  [ApiController]
  public class BusinessesController : ControllerBase
  {
    private readonly LocalApiContext _db;

    public BusinessesController(LocalApiContext db)
    {
      _db = db;
    }

    /// <summary>
    /// Business List
    /// </summary>
    /// <returns>Business List</returns>
    /// <response code="200">Returns Business List</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Business>>> Get(string name, string description, string location)
    {
      var query = _db.Businesses.AsQueryable();

      if (description != null)
      {
        query = query.Where(entry => entry.Description == description);
      }

      if (location != null)
      {
        query = query.Where(entry => entry.Location == location);
      }    

      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }      

      return await query.ToListAsync();
    }

    /// <summary>
    /// Find business by Id
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// GET /api/businesses/1    
    /// </remarks> 
    /// <returns>Return business by Id</returns>
    /// <response code="200">Returns business</response> 
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
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

    /// <summary>
    /// Update business 
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// PUT /api/businesses/1     
    /// </remarks>
    /// <returns>Update business in API</returns>
    /// <response code="201">business update Successfully</response> 
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
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

    /// <summary>
    /// Creates business.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///     POST /Businesses
    ///     {
    ///        "id": 1,
    ///        "name": "business name",
    ///        "description": "description of business"
    ///        "location": "location of business"
    ///     }
    /// </remarks>
    /// <returns>A newly created business</returns>
    /// <response code="201">Returns the newly created business</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Business>> Post(Business business)
    {
      _db.Businesses.Add(business);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetBusiness), new { id = business.BusinessId }, business);
    }

    /// <summary>
    /// Delete business 
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// DELETE /api/businesses/1    
    /// </remarks>
    /// <returns>business List</returns>
    /// <response code="201">Business deleted successfully</response>  
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

    private bool BusinessExists(int id)
    {
      return _db.Businesses.Any(e => e.BusinessId == id);
    }
  }
}