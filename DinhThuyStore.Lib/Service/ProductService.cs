using DinhThuyStore.Lib.Database;
using DinhThuyStore.Lib.Dtos;
using DinhThuyStore.Lib.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinhThuyStore.Lib.Service
{
    public class ProductService : ProductInterface
    {
        private readonly DbExecute _db;

        public ProductService()
        {
            _db = new SqlExecute();
        }
        public List<ProductDto> GetAll()
        {
            List<ProductDto> list = new List<ProductDto>();
            var dt = _db.Execute_Table("Product_GetAll", null, CommandType.StoredProcedure);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ProductDto product = new ProductDto();
                    product.PKID = Convert.ToInt32(dt.Rows[i]["PKID"]);
                    product.CategoryID = Convert.ToInt32(dt.Rows[i]["CategoryID"]);
                    product.CategoryName = dt.Rows[i]["CategoryName"].ToString();
                    product.ProductCode = dt.Rows[i]["ProductCode"].ToString();
                    product.ProductName = dt.Rows[i]["ProductName"].ToString();
                    product.Image = dt.Rows[i]["Image"].ToString();
                    product.Price = dt.Rows[i]["Price"].ToString();
                    product.Quantity = Convert.ToInt32(dt.Rows[i]["Quantity"]);
                    product.IsActive = Convert.ToBoolean(dt.Rows[i]["IsActive"]);
                    product.CreatedDate = Convert.ToDateTime(dt.Rows[i]["CreatedDate"]);
                    list.Add(product);
                }
            }
            return list;
        }
    }
}
