using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;
using System.Linq;

namespace ToDoList.Controllers
{
  public class ItemsController : Controller
  {
    //hold db connection as todoliscontext type
    private readonly ToDoListContext _db;

    public ItemsController(ToDoListContext db) //passed as arg thru dependency injection. this arg is same todolistcontext setup as service in program.cs
    {
      _db = db; //set value of _db prop to Todolistocntext dbl.
    }
    public ActionResult Index()
    {
      List<Item> model = _db.Items.ToList(); //replaces getall() uses linq
      return View(model);
    }
    // [HttpGet("/categories/{categoryId}/items/new")]
    // public ActionResult New(int categoryId)
    // {
    //   Category category = Category.Find(categoryId);
    //   return View(category);
    // }
    
    // [HttpGet("/categories/{categoryId}/items/{itemId}")]
    // public ActionResult Show(int categoryId, int itemId)
    // {
    //   Item item = Item.Find(itemId);
    //   Category category = Category.Find(categoryId);
    //   Dictionary<string, object> model = new Dictionary<string, object>();
    //   model.Add("item", item);
    //   model.Add("category", category);
    //   return View(model); //passed cat&item id to view in dictionary
    // }
  }
}