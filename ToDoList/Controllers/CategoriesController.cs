using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using Sytem.Linq;

namespace ToDoList.Controllers
{
  public class CategoriesController : Controller
  {
    private readonly ToDoListContext _db;
    public CategoriesController(ToDoListContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      List<Category> model = _db.Categories.ToList(); //getall w linq
      return View(model);
    }
    public ActionResult Create()
    {
      return View();
    }
    [HttpPost]
    public ActionResult Create(Category category)
    {
      _db.Categories.Add(item);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      Category thisCategory = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
    }
    public ActionResult Edit(int id)
    {
      Category thisCategory = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
      return View(thisCategory);
    }
    [HttpPost]
    public ActionResult Edit(Category category)
    {
      _db.Categories.Update(category);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Delete(int id)
    {
      Category thisCategory = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
      return View(thisItem);
    }
    [HttpPost ActionName("Delete")]
    public ActionResult DeleteCofirmed(int id)
    {
      Category thisCategory = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
      _db.Categories.Remove(thisCategory);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}