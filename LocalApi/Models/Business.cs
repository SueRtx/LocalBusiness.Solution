using System.ComponentModel.DataAnnotations;

namespace LocalApi.Models
{
  public class Business
  {
    public int BusinessId { get; set; }
    [Required]
    [StringLength(20)]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public string Location { get; set; }

  }
}