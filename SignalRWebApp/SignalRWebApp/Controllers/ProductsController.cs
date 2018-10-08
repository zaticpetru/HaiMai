using Microsoft.AspNet.Identity;
using SignalRWebApp.Models;
using SignalRWebApp.SqlServerNotifier;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SignalRWebApp.Controllers
{
    public class ProductsController : Controller
    {
        private SignaRTestContext db = new SignaRTestContext();

        public async Task<ActionResult> Index()
        {
            var collection = db.Products;
            ViewBag.NotifierEntity = db.GetNotifierEntity<Product>(collection).ToJson();
            return View(await collection.ToListAsync());
        }

        public async Task<ActionResult> IndexPartial()
        {
            var collection = db.Products;
            ViewBag.NotifierEntity = db.GetNotifierEntity<Product>(collection).ToJson();
            return PartialView(await collection.ToListAsync());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include ="Name, UnitPrice, Quantity, UserName")]Product product)
        {
            try
            {
                if (ModelState.IsValid && this.User.Identity.Name == product.UserName)
                {
                    product.UserId = User.Identity.GetUserId();
                    db.Products.Add(product);
                    db.SaveChanges();
                    ViewBag.Succes = "Product " + product.Name + " succeseful added";
                    return View();
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again or see your administrator");
            }
            return View(product);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        [HttpGet]
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult EditPost(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var productToUpdate = db.Products.Find(id);
            if(TryUpdateModel(productToUpdate,"",
                new string[] { "Name", "UnitPrice", "Quantity", "UserName" }))
            {
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DataException)
                {
                    ModelState.AddModelError("", "Error saving changes, try again or see your");
                }
            }
            return View(productToUpdate);
        }
       // [HttpDelete]
       [Authorize]
        public ActionResult Delete(int? id, bool? saveChangesError=false)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, or see your admin";
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Delete(int id)
        {
            try
            {
                Product product = db.Products.Find(id);
                db.Products.Remove(product);
                db.SaveChanges();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
