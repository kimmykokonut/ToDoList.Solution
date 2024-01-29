using System.Collections.Generic;
using MySqlConnector;

namespace ToDoList.Models
{
  public class Item
  {
    public string Description { get; set; }
    public int ItemId { get; set; } 

    public Item(string description)
    {
      Description = description;
    }
    public Item(string description, int id)
    {
      Description = description;
      ItemId = id;
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
        bool idEquality = (this.ItemId == newItem.ItemId);
        bool descriptionEquality = (this.Description == newItem.Description);
        return (idEquality && descriptionEquality);
      }
    }
    public override int GetHashCode()
    {
      return ItemId.GetHashCode();
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
      ItemId = (int) cmd.LastInsertedId; //explicit cast b/c db returns 'long' not 'int'

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
    public static Item Find(int id)
    {
      //open connection
      MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
      conn.Open();
      //create msc obj and add query to its c.txt prop. Always need to do
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = "SELECT * FROM items WHERE id = @ThisId;";
      //use param placeholder&msp obj to prevent sql inj. attacks-only necessary when passing param into query
      MySqlParameter param = new MySqlParameter();
      param.ParameterName = "@ThisId";
      param.Value = id;
      cmd.Parameters.Add(param);
      //use exe.reader b/c query returning results
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      int itemId = 0;
      string itemDescription = ""; // incase find doesn't return a result
      while (rdr.Read())
      {
        itemId = rdr.GetInt32(0);
        itemDescription = rdr.GetString(1);
      }
      Item foundItem = new Item(itemDescription, itemId);
      //close connection
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return foundItem;
    }
  }
}