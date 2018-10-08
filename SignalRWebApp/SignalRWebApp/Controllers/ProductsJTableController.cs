using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SignalRWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserStore.BLL.DTO;
using UserStore.BLL.Interfaces;
using UserStore.BLL.Services;

namespace SignalRWebApp.Controllers
{
    [Authorize(Roles = "admin")]
    public class ProductsJTableController : Controller
    {
        // GET: ProductsJTable
        private SignaRTestContext db = new SignaRTestContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult ProductList(int jtStartIndex, int jtPageSize)
        {
            try
            {
                //List<Product> products = db.Products.ToList();
                var products = db.Products.OrderBy(x => x.Name).Skip(jtStartIndex).Take(jtPageSize).ToList();
                int productCount = db.Products.Count();
                return Json(new { Result = "OK", Records = products, TotalRecordCount = productCount });
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
                db.SaveChanges();
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        private IUserService UserService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IUserService>();
            }
        }
        [HttpPost]
        public JsonResult UserList()
        {
            {
                try
                {
                    var users = UserService.GetUsers().Select(
                        x => new { DisplayText = x.UserName, Value = x.Id });

                    return Json(new { Result = "OK", Records = users });
                }
                catch (Exception ex)
                {
                    return Json(new { Result = "ERROR", Message = ex.Message });
                }
            }
        }
    }
}