using System.Collections.Generic;
using MySqlConnector;

namespace ToDoList.Models
{
  public class Item
  {
    public string Description { get; set; }
    public int Id { get; set; } 

    public Item(string description)
    {
      Description = description;
    }
    public Item(string description, int id)
    {
      Description = description;
      Id = id;
    }
    public override bool Equals(System.Object otherItem)
    {
      if (!(otherItem is Item)) //makes sure its Item obj
      {
        return false;
      }
      else
      {
        Item newItem = (Item) otherItem; //type cast to ensure otheritem is an Item
        bool idEquality = (this.Id == newItem.Id);
        bool descriptionEquality = (this.Description == newItem.Description);
        return (idEquality && descriptionEquality);
      }
    }
    public override int GetHashCode()
    {
      return Id.GetHashCode();
    }
    public void Save()
    {
      MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
      conn.Open();

      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;

      cmd.CommandText = "INSERT INTO items (description) VALUES (@ItemDescription);";
      //passing MySqlParameter Object into SqlCommand
      MySqlParameter param = new MySqlParameter();
      param.ParameterName = "@ItemDescription";
      param.Value = this.Description; //refers auto-impl. property Description
      cmd.Parameters.Add(param);
      cmd.ExecuteNonQuery(); //will save row in db.
      Id = (int) cmd.LastInsertedId; //explicit cast b/c db returns 'long' not 'int'

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
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
      MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString); //create conn object
      conn.Open(); //opens db connection

      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand; //create new command obj.
      cmd.CommandText = "DELETE FROM items;"; //sql command
      cmd.ExecuteNonQuery(); //modify data (not query/return data)

      conn.Close();
      if (conn != null)
      {
        conn.Dispose(); //destroy if not closed correctly
      }
    }
    public static Item Find(int searchId)
    {
      Item placeholderItem = new Item("placeholder item");
      return placeholderItem;
    }
    
  }
}