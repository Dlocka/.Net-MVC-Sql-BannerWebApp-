using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;

namespace MVCWork.DAL.Poducts
{
    public class ProductInfoService
    {
        public List<Product>GetHomePageExhProducts(int PageLabel)
        {
            using (ElectronicMarketEntities electronicMarketEntities = new ElectronicMarketEntities())
            {
                SqlParameter sqlParameter= new SqlParameter("@page", PageLabel);
                SqlParameter[] paras = new SqlParameter[] { sqlParameter };
                
                //var obj1;
                List<Product> products =electronicMarketEntities.Database.SqlQuery<Product>
                    ("select* from product where ProductID in (select ProductID from HomePageExhibitPro where PageLabel = @page) ",paras).ToList();

              
            return products;
            }
        }

        public List<Product> SearchComplementProducts(string inputString)
        {
            using (ElectronicMarketEntities electronicMarketEntities = new ElectronicMarketEntities())
            {
                var products = electronicMarketEntities.Product
                   .Where(p => p.ProductName.Contains("ip"))
                   .OrderBy(p => !p.ProductName.StartsWith("ip"))
                   .ThenBy(p => p.ProductName)
                   .Take(10)
                   .ToList();
                return products;
            }
        }
    }
}
