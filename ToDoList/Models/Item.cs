using System.Collections.Generic;
using MySqlConnector;

namespace ToDoList.Models
{
  public class Item
  {
    public string Description { get; set; }
    public int Id { get; } //don't need set b/c set automatically in constructor

    public Item(string description)
    {
      Description = description;
    }
    public Item(string description, int id)
    {
      Description = description;
      Id = id;
    }
    public static List<Item> GetAll()
    {
      List<Item> allItems = new List<Item> { };
      //open new db connection
      MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString); 
      conn.Open();
      //construct SQL query stored in obj MySqlCommand. the 'as' casts cmd into msc obj.
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      //add actual text of sql command, store in CommandText property
      cmd.CommandText = "SELECT * FROM items;";
      //create data reader object responsible for reading data returned from db. cast type w/'as'
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read()) //built in Read(). returns boolean. //in loop take ea record from db and translate that record into an Item obj
      {   
        int itemId = rdr.GetInt32(0); //0 index of array. id column at index 0, desc@index 1
        string itemDescription = rdr.GetString(1);
        Item newItem = new Item(itemDescription, itemId);
        allItems.Add(newItem);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allItems;
    }
    public static void ClearAll()
    {
      
    }
    public static Item Find(int searchId)
    {
      Item placeholderItem = new Item("placeholder item");
      return placeholderItem;
    }
    
  }
}