using System.ComponentModel.DataAnnotations;

namespace LocalApi.Models
{
  public class Business
  {
    public int BusinessId { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public string Location { get; set; }

  }
}