using SignalRWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SignalRWebApp.Controllers
{
    public class ProductsJTableController : Controller
    {
        // GET: ProductsJTable
        private SignaRTestContext db = new SignaRTestContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult ProductList()
        {
            try
            {
                List<Product> products = db.Products.ToList();
                return Json(new { Result = "OK", Records = products });
            }catch(Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        [HttpPost]
        public JsonResult CreateProduct(Product product)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new
                    {
                        Result = "ERROR",
                        Message = "Form is not valid! " +
                      "Please correct it and try again."
                    });
                }

                var addedProduct = db.Products.Add(product);
                db.SaveChanges();
                return Json(new { Result = "OK", Record = addedProduct });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        [HttpPost]
        public JsonResult UpdateProduct(Product product)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new
                    {
                        Result = "ERROR",
                        Message = "Form is not valid! " +
                        "Please correct it and try again."
                    });
                }

                db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        [HttpPost]
        public JsonResult DeleteProduct(int productId)
        {
            try
            {
                Product product = db.Products.Find(productId);
                db.Products.Remove(product);
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
    }
}