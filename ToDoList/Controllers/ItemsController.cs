using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

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
      List<Item> model = _db.Items
              .Include(item => item.Category) //includes category w/item
              .ToList(); //replaces getall() uses linq
      return View(model);
    }
    //[HttpGet]
    public ActionResult Create() //replaces the New()
    {
      ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name"); //selectlist provides data needed to create html sleect of all categories from db.
      return View();
    }
    [HttpPost]
    public ActionResult Create(Item item)
    {
      if (!ModelState.IsValid) //model validation don't want categoryId to =0/not exist. ea item Needs a category.
      {
        ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
        return View(item);
      }
      _db.Items.Add(item);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id) //id match param from actionlink in index.
    {
      Item thisItem = _db.Items
      .Include(item => item.Category)
      .Include(item => item.JoinEntities) //fetch join.ent
      .ThenInclude(join => join.Tag) //fetch tag object
      .FirstOrDefault(item => item.ItemId == id);
      return View(thisItem);
    }
    //line 36 same code: Item thisItem = _db.Items.FirstOrDefault(thing => thing.ItemId == id);
    public ActionResult Edit(int id)
    {
      Item thisItem = _db.Items.FirstOrDefault(item => item.ItemId == id);
      ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
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
    public ActionResult AddTag(int id)
    {
      Item thisItem = _db.Items.FirstOrDefault(items => items.ItemId == id);
      ViewBag.TagId = new SelectList(_db.Tags, "TagId", "Title");
      return View(thisItem);
    }
    [HttpPost]
    public ActionResult AddTag(Item item, int tagId)
    {
      #nullable enable
      ItemTag? joinEntity = _db.ItemTags.FirstOrDefault(join => (join.TagId == tagId && join.ItemId == item.ItemId));
      #nullable disable
      if (joinEntity == null && tagId != 0)
      {
        _db.ItemTags.Add(new ItemTag() { TagId = tagId, ItemId = item.ItemId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = item.ItemId });
    }
    [HttpPost]
    public ActionResult DeleteJoin(int joinId)
    {
      ItemTag joinEntry = _db.ItemTags.FirstOrDefault(entry => entry.ItemTagId == joinId);
      _db.ItemTags.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}