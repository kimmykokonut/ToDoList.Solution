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
    //[HttpGet]
    public ActionResult Create() //replaces the New()
    {
      return View();
    }
    [HttpPost]
    public ActionResult Create(Item item)
    {
      _db.Items.Add(item);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id) //id match param from actionlink in index.
    {
      Item thisItem = _db.Items.FirstOrDefault(item => item.ItemId == id);
      return View(thisItem);
    }
    //line 36 same code: Item thisItem = _db.Items.FirstOrDefault(thing => thing.ItemId == id);
    public ActionResult Edit(int id)
    {
      Item thisItem = _db.Items.FirstOrDefault(item => item.ItemId == id);
      return View(thisItem);
    }
    [HttpPost]
    public ActionResult Edit(Item item)
    {
      _db.Items.Update(item);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Delete(int id)
    { //gets item from db return to view
      Item thisItem = _db.Items.FirstOrDefault(item => item.ItemId == id);
      return View(thisItem);
    }
    [HttpPost, ActionName("Delete")] //need this b/c both get/post take id as parameter. c# no allow two method w/same signature.
    public ActionResult DeleteConfirmed(int id)
    {
      Item thisItem = _db.Items.FirstOrDefault(item => item.ItemId == id);
      _db.Items.Remove(thisItem);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}