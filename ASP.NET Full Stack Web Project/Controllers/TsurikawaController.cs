using ASP.NET_Full_Stack_Web_Project.Data;
using ASP.NET_Full_Stack_Web_Project.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Full_Stack_Web_Project.Controllers
{
    public class TsurikawaController : Controller
    {
        private ProductContext dbContext;

        public TsurikawaController(ProductContext s)
        {
            dbContext = s;
        }

        public IActionResult ShowAllTsurikawas()
        {
            return View(dbContext.Kawa.ToList());
        }

        [HttpGet]
        public IActionResult AddTsurikawa()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTsurikawa(Tsurikawa t)
        {
            if (!ModelState.IsValid) //if the information sent to the server is NOT valid
            {
                return View();
            }

            dbContext.Kawa.Add(t);
            dbContext.SaveChanges();

            return RedirectToAction("ShowAllTsurikawas");
        }

        [HttpGet]
        public IActionResult EditTsurikawa(int id)
        {
            //find the right data
            var tsuri = dbContext.Kawa.SingleOrDefault(tsuri => tsuri.ID == id);

            if (tsuri == null) //product id not found
                return NotFound();

            //pass it to the view
            return View(tsuri);
        }

        [HttpPost]
        public IActionResult EditTsurikawa(Tsurikawa t)
        {
            //p will represent the product with values changed/edited

            if (!ModelState.IsValid) //if the information sent to the server is NOT valid
            {
                return View();
            }

            //assume id has not changed
            //search in the database for the old product
            var oldTsurikawa = dbContext.Kawa.SingleOrDefault(product => product.ID == t.ID);
            oldTsurikawa.Color = t.Color;
            oldTsurikawa.Description = t.Description;
            oldTsurikawa.Name = t.Name;
            oldTsurikawa.Price = t.Price;
            oldTsurikawa.ID = t.ID;

            //save those changes into the DBSet
            dbContext.Kawa.Update(oldTsurikawa);

            //save changes to the database
            dbContext.SaveChanges();



            return RedirectToAction("ShowAllTsurikawas");
        }

        public IActionResult Delete(int id)
        {
            Tsurikawa t = dbContext.Kawa.SingleOrDefault(tsuri => tsuri.ID == id);
            if (t == null) //product id not found
                return NotFound();

            dbContext.Kawa.Remove(t); //delete p from my dbset
            dbContext.SaveChanges(); //deletes p from the database

            return RedirectToAction("ShowAllTsurikawas");
        }




        public IActionResult ShowTsurikawa(int id)
        {
            Tsurikawa t = dbContext.Kawa.SingleOrDefault(Tsurikawa => Tsurikawa.ID == id);


            if (t == null) //product id not found
                return NotFound();

            return View();
        }



    }
}
