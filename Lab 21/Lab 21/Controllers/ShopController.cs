using Lab_21.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab_21.Controllers
{
    public class ShopController : Controller
    {
        ShopDbEntities ORM = new ShopDbEntities();
        // GET: Movie
        public ActionResult Index()
        {
            ViewBag.ItemList = ORM.Items.ToList();
            return View();
        }

        public ActionResult UpdateItem(int ItemID)
        {
            Item found = ORM.Items.Find(ItemID);

            //if(ModelState.IsValid)
            //{

            //}

            return View(found);
        }

        public ActionResult SaveChanges(Item updateItem)
        {
            Item originalItem = ORM.Items.Find(updateItem.Id);

            if (originalItem != null && ModelState.IsValid)
            {
                originalItem.Name = updateItem.Name;
                originalItem.Description = updateItem.Description;
                originalItem.Quantity = updateItem.Quantity;
                originalItem.Price = updateItem.Price;

                ORM.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "Something did not go right. Try again.";
                return RedirectToAction("UpdateItem", updateItem.Id);
            }
        }

        public ActionResult DeleteItem(int ItemID)
        {
            Item found = ORM.Items.Find(ItemID);
            ORM.Items.Remove(found);
            ORM.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SaveNewItem(Item newItem)
        {
            if (ModelState.IsValid)
            {
                ORM.Items.Add(newItem);
                ORM.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "Something didn't go right..";
                return View("ItemForm");
            }
        }

        public ActionResult ItemForm()
        {
            return View();
        }
    }
}