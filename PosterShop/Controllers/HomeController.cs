using Model.EF;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PosterShop.Controllers
{
    public class HomeController : Controller
    {
        private PosterShopDbContext db = new PosterShopDbContext();

        public ActionResult Index()
        {
            ViewBag.FeaturedProduct = new List<Product>(db.Products.Where(x => x.ProCatID == 3).OrderByDescending(x => x.CreatedDate).Take(4).ToList());
            ViewBag.ResentProduct = new List<Product>(db.Products.Where(x => x.TopHot != null && x.TopHot > System.DateTime.Now).OrderByDescending(x => x.CreatedDate).Take(4).ToList());
            return View();
        }

        public PartialViewResult Menu_Vertical()
        {
            return PartialView(db.ProductCategories.Where(x => x.Status == true).ToList());
        }

        public ActionResult Category(int id)
        {
            var products = db.Products.Where(x => x.ProCatID == id).ToList();
            ViewBag.ProductCategory = db.ProductCategories.Find(id);
            return View(products);
        }

        //Delay
        public ActionResult ProductDetails(int id)
        {
            var product = db.Products.Find(id);
            ViewBag.ProductCategory = db.ProductCategories.Find(product.ProCatID);
            ViewBag.RelatedProduct = new List<Product>(db.Products.Where(x => x.ID != id && x.ProCatID == product.ProCatID).OrderByDescending(x => x.CreatedDate).Take(4).ToList());
            return View(product);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}