using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCWork.Models;
using MVCWork.DAL;
using MVCWork.DAL.Poducts;
using System.Web.Mvc;
namespace MVCWork.BLL
{
    public class ProductInfoManager
    {
        
        public List<Product_Model> GetHomePageExhProducts(int PageLabel)
        {
            ProductInfoService productInfoService = new ProductInfoService();
            List<Product> products_list=productInfoService.GetHomePageExhProducts(PageLabel);
            List<Product_Model> products_bll_list = new List<Product_Model>();
            foreach (var product in products_list)
            {
                 Product_Model product_Model = new Product_Model() { ProductID=product.ProductID, Description=product.Description, Image= product.Image, Price=product.Price, };
                products_bll_list.Add(product_Model);
            }
            return products_bll_list;
        }

        public List<Product_Model> SearchComplementProducts(string InputString)
        {
            ProductInfoService productInfoService = new ProductInfoService();
            List<Product> CompletePorudcts=productInfoService.SearchComplementProducts(InputString);
            List<Product_Model> product_Models = new List<Product_Model>();
            foreach (var item in CompletePorudcts)
            {
                Product_Model product_Model = new Product_Model() { ProductName = item.ProductName };
                product_Models.Add(product_Model);
            }
            return product_Models;
        }
    }
}
