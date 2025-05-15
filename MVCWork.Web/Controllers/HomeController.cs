using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCWork.Web.Models;
using MVCWork.Models;
using MVCWork.BLL;
namespace MVCWork.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        public ActionResult First()
        {
            
            return View();
        }

        public ActionResult GetExhibitProduct_HomePage(int LabelNumber)
        {
            ProductInfoManager productInfoManager = new ProductInfoManager();
            List<Product_Model> product_Models = new List<Product_Model>();
            List<HomePageExhibitProduct_Web> productlist = new List<HomePageExhibitProduct_Web>();
            product_Models = productInfoManager.GetHomePageExhProducts(LabelNumber);
            foreach (var product in product_Models)
            {
                HomePageExhibitProduct_Web exhibitProduct = new HomePageExhibitProduct_Web() { description = product.Description, Image=product.Image, price=product.Price};
                productlist.Add(exhibitProduct);
            }
            //商品列表数据
            #region
            //for (int i = 0; i < 3; i++)
            //{
            //    HomePageExhibitProduct_Web item=new HomePageExhibitProduct_Web() {price=25, description="aaa", Image="~/Images/product_1_1.jpg" };
            //    productlist.Add(item);
            //}
            //HomePageExhibitProduct_Web item1 = new HomePageExhibitProduct_Web() { price = 25, description = "abc", Image = "~/Images/product_1_1.jpg" };
            //productlist.Add(item1);
            //HomePageExhibitProduct_Web item2 = new HomePageExhibitProduct_Web() { price = 25, description = "cba", Image = "~/Images/product_1_1.jpg" };
            //productlist.Add(item2);
            #endregion
            return Json(new { success = true, message = "Get Successfully", products=productlist});
        }
    }
}