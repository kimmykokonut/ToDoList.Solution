using System.Collections.Generic;

namespace ToDoList.Models
{
  public class Item
  {
    public string Description { get; set; }
    public int Id { get; } //don't need set b/c set automatically in constructor
    private static List<Item> _instances = new List<Item> { };

    public Item(string description)
    {
      Description = description;
      _instances.Add(this);
      Id = _instances.Count;
    }
    public static List<Item> GetAll()
    {
      return _instances;
    }
    public static void ClearAll()
    {
      _instances.Clear();
    }
    public static Item Find(int searchId)
    {
      return _instances[searchId-1]; // -1 b/c index location != reality
    }
    
  }
}