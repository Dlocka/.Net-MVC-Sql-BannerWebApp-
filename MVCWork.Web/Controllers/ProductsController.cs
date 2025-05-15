using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCWork.Models;
using MVCWork.BLL;
namespace MVCWork.Web.Controllers
{
    public class ProductsController : Controller
    {
      
        [HttpGet]
        public JsonResult CompleteSearchProducts(string inputString)
        {
            ProductInfoManager productInfoManager = new ProductInfoManager();
            List<Product_Model> products = productInfoManager.SearchComplementProducts(inputString);
            return Json(products, JsonRequestBehavior.AllowGet);
        }
    }
}