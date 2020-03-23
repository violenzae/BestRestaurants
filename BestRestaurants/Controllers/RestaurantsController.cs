using Microsoft.AspNetCore.Mvc;
using BestRestaurants.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BestRestaurants.Controllers
{
  public class RestaurantsController : Controller
  {
    private readonly BestRestaurantsContext _db;

    public RestaurantsController(BestRestaurantsContext db)
    {
      _db = db;
    }
    

    public ActionResult Index()
    {
      // List<Restaurant> model = _db.Restaurants.Include(restaurants => restaurants.Cuisine).ToList();
      // return View(model);

      // List<Restaurant> model = _db.Restaurants.ToList();
      // return View(model);
      return View(_db.Restaurants.ToList());
    }
    
    public ActionResult Details(int id)
    {
      var thisRestaurant = _db.Restaurants
        .Include(restaurant => restaurant.Cuisines)
        .ThenInclude(join => join.Cuisine)
        .FirstOrDefault(restaurant => restaurant.RestaurantId == id);
      return View(thisRestaurant);
    }
    
  }
}
//     public ActionResult Create()
//     {
//       ViewBag.CuisineId = new SelectList(_db.Cuisines, "CuisineId", "Name");
//       return View();
//     }

//     [HttpPost]
//     public ActionResult Create(Restaurant restaurant)
//     {
//       _db.Restaurants.Add(restaurant);
//       _db.SaveChanges();
//       return RedirectToAction("Index");
//     }


    
//     public ActionResult Edit(int id)
//     {
//         var thisRestaurant = _db.Restaurants.FirstOrDefault(restaurants => restaurants.RestaurantId == id);
//         return View(thisRestaurant);
//     }

//     [HttpPost]
//     public ActionResult Edit(Restaurant restaurant)
//     {
//       _db.Entry(restaurant).State = EntityState.Modified;
//       _db.SaveChanges();
//       return RedirectToAction("Index");
//     }

//   public ActionResult Delete(int id)
//   {
//       var thisRestaurant = _db.Restaurants.FirstOrDefault(restaraunts => restaraunts.RestaurantId == id);
//       return View(thisRestaurant);
//   }

//   [HttpPost, ActionName("Delete")]
//   public ActionResult DeleteConfirmed(int id)
//   {
//       var thisRestaurant = _db.Restaurants.FirstOrDefault(restaurants => restaurants.RestaurantId == id);
//       _db.Restaurants.Remove(thisRestaurant);
//       _db.SaveChanges();
//       return RedirectToAction("Index");
//   }
//   }
// }