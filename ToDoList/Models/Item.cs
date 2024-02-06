using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
  public class Item
  {
    public int ItemId { get; set; }
    public string Description { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "You must add your item to a category. Have you created a category yet?")]
    public int CategoryId { get; set; } //foregin key in items db
    public Category Category { get; set; } //nav prop creates 1:many
    public List<ItemTag> JoinEntities { get; } //collection nav prop.

  }
}