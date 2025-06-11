using System.ComponentModel.DataAnnotations.Schema;

namespace RestService.Model;

[Table("item")]
public class Item
{
    [Column(name: "id")]
    public int Id { get; set; }
    
    [Column(name: "name")]
    public string Name { get; set; }
    
    [Column(name: "description")]
    public string Description { get; set; }
}