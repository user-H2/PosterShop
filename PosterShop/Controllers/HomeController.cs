using Model.EF;
using System.Linq;
using System.Web.Mvc;

namespace PosterShop.Controllers
{
    public class HomeController : Controller
    {
        private PosterShopDbContext db = new PosterShopDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Menu_Vertical()
        {
            return PartialView(db.ProductCategories.Where(x => x.Status == true).ToList());
        }

        public ActionResult Category(int id)
        {
            return View(db.Products.Where(x => x.ProCatID == id).ToList());
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