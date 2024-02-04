using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ToDoList.Controllers;

public class TagsController : Controller
{
  private readonly ToDoListContext _db;
  public TagsController(ToDoListContext db)
  {
    _db = db;
  }
  public ActionResult Index()
  {
    return View(_db.Tags.ToList());
  }
  public ActionResult Detail(int id)
  {
    Tag thisTag = _db.Tags
      .Include(tag => tag.JoinEntities) //load JE prop of ea Tag (not actual item objects related to Tag. ItemTag is ref. to relationship, incl. id of Tag and id of Item)
      .ThenInclude(join => join.Item) //actual Item objects ass'd w/ItemTag
      .FirstOrDefault(tag => tag.TagId == id);
    return View(thisTag);
  }
  public ActionResult Create()
  {
    return View();
  }
  [HttpPost]
  public ActionResult Create(Tag tag)
  {
    _db.Tags.Add(tag);
    _db.SaveChanges();
    return RedirectToAction("Index");
  }
  public ActionResult AddItem(int id)
  {
    Tag thisTag = _db.Tags.FirstOrDefault(tags => tags.TagId == id);
    ViewBag.ItemId = new SelectList(_db.Items, "ItemId", "Description");
    return View(thisTag);
  }
  [HttpPost]
  public ActionResult AddItem(Tag tag, int itemId)
  {
    #nullable enable
    ItemTag? joinEntity = _db.ItemTags.FirstOrDefault(join => (join.ItemId == itemId && join.TagId == tag.TagId));
  }
}