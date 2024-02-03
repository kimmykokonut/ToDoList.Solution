using System.Collections.Generic;

namespace ToDoList.Models
{
  public class Item
  {
    public int ItemId { get; set; }
    public string Description { get; set; }
    public int CategoryId { get; set; } //foregin key in items db
    public Category Category { get; set; } //nav prop creates 1:many
    public List<ItemTag> JoinEntities { get; } //collection nav prop.

  }
}