using ASP.NET_Full_Stack_Web_Project.Data;
using ASP.NET_Full_Stack_Web_Project.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Full_Stack_Web_Project.Controllers
{
    public class AirFreshnerController : Controller
    {
        private ProductContext dbContext;

        public AirFreshnerController(ProductContext s)
        {
            dbContext = s;
        }

        public IActionResult ShowAllAirFreshners()
        {
            return View(dbContext.Freshner.ToList());
        }

        [HttpGet]
        public IActionResult AddAirFreshner()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAirFreshner(AirFreshner t)
        {
            if (!ModelState.IsValid) //if the information sent to the server is NOT valid
            {
                return View();
            }

            dbContext.Freshner.Add(t);
            dbContext.SaveChanges();

            return RedirectToAction("ShowAllAirFreshners");
        }

        [HttpGet]
        public IActionResult EditAirFreshner(int id)
        {
            //find the right data
            var air = dbContext.Freshner.SingleOrDefault(tsuri => tsuri.ID == id);

            if (air == null) //product id not found
                return NotFound();

            //pass it to the view
            return View(air);
        }

        [HttpPost]
        public IActionResult EditAirFreshner(AirFreshner t)
        {
            //p will represent the product with values changed/edited

            if (!ModelState.IsValid) //if the information sent to the server is NOT valid
            {
                return View();
            }

            //assume id has not changed
            //search in the database for the old product
            var oldAirFreshner = dbContext.Freshner.SingleOrDefault(product => product.ID == t.ID);
            oldAirFreshner.Scent = t.Scent;
            oldAirFreshner.Description = t.Description;
            oldAirFreshner.Name = t.Name;
            oldAirFreshner.Price = t.Price;
            oldAirFreshner.ID = t.ID;

            //save those changes into the DBSet
            dbContext.Freshner.Update(oldAirFreshner);

            //save changes to the database
            dbContext.SaveChanges();



            return RedirectToAction("ShowAllAirFreshners");
        }

        public IActionResult DeleteAirFreshner(int id)
        {
            AirFreshner t = dbContext.Freshner.SingleOrDefault(Fresh => Fresh.ID == id);
            if (t == null) //product id not found
                return NotFound();

            dbContext.Freshner.Remove(t); //delete p from my dbset
            dbContext.SaveChanges(); //deletes p from the database

            return RedirectToAction("ShowAllAirFreshners");
        }




        public IActionResult ShowAirFreshner(int id)
        {
            AirFreshner t = dbContext.Freshner.SingleOrDefault(AirFreshner => AirFreshner.ID == id);


            if (t == null) //product id not found
                return NotFound();

            return View();
        }



    }

}
