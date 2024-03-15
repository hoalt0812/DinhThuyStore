using DinhThuyStore.Lib.Database;
using DinhThuyStore.Lib.Dtos;
using DinhThuyStore.Lib.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
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

        public bool CheckProductCode(string productCode)
        {
            var paras = new SqlParameter[1];
            paras[0] = new SqlParameter("@ProductCode", productCode);
            var rs = _db.Execute_Table("Product_GetByProductCode", paras, CommandType.StoredProcedure);
            if (rs.Rows.Count > 0)
            {
                return false;
            }
            return true;
        }

        public int Create(ProductDto model)
        {
            var paras = new SqlParameter[8];
            paras[0] = new SqlParameter("@Rs", SqlDbType.Int) { Direction = ParameterDirection.Output };
            paras[1] = new SqlParameter("@CategoryID", model.CategoryID);
            paras[2] = new SqlParameter("@ProductCode", model.ProductCode);
            paras[3] = new SqlParameter("@ProductName", model.ProductName);
            paras[4] = new SqlParameter("@Image", model.Image);
            paras[5] = new SqlParameter("@Price", model.Price);
            paras[6] = new SqlParameter("@Quantity", model.Quantity);
            paras[7] = new SqlParameter("@IsActive", model.IsActive);
            var rs = _db.Execute_Modify("Product_Insert", paras, CommandType.StoredProcedure);
            if (rs > 0) return (int)paras[0].Value;
            return rs;
        }

        public int Delete(int id)
        {
            var paras = new SqlParameter[2];
            paras[0] = new SqlParameter("@Rs", SqlDbType.Int) { Direction = ParameterDirection.Output };
            paras[1] = new SqlParameter("@PKID", id);
            var rs = _db.Execute_Modify("Product_Delete", paras, CommandType.StoredProcedure);
            if (rs > 0) return (int)paras[0].Value;
            return rs;
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

        public List<ProductDto> GetByCategoryID(int id)
        {
            var paras = new SqlParameter[1];
            paras[0] = new SqlParameter("@CategoryID", id);
            List<ProductDto> list = new List<ProductDto>();
            var dt = _db.Execute_Table("Product_GetByCategoryID", paras, CommandType.StoredProcedure);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ProductDto product = new ProductDto();
                    product.PKID = Convert.ToInt32(dt.Rows[i]["PKID"]);
                    product.CategoryID = Convert.ToInt32(dt.Rows[i]["CategoryID"]);
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

        public ProductDto GetByPKID(int id)
        {
            var laser = new ProductDto();
            var paras = new SqlParameter[1];
            paras[0] = new SqlParameter("@PKID", id);
            var tb = _db.Execute_Table("Product_GetByPKID", paras, CommandType.StoredProcedure);
            if (tb != null)
            {
                if (tb.Rows.Count > 0)
                {
                    laser.PKID = Convert.ToInt32(tb.Rows[0]["PKID"]);
                    laser.CategoryID = Convert.ToInt32(tb.Rows[0]["CategoryID"]);
                    laser.ProductCode = tb.Rows[0]["ProductCode"].ToString();
                    laser.ProductName = tb.Rows[0]["ProductName"].ToString();
                    laser.Image = tb.Rows[0]["Image"].ToString();
                    laser.Price = tb.Rows[0]["Price"].ToString();
                    laser.Quantity = Convert.ToInt32(tb.Rows[0]["Quantity"]);
                    laser.IsActive = Convert.ToBoolean(tb.Rows[0]["IsActive"]);
                    laser.CreatedDate = Convert.ToDateTime(tb.Rows[0]["CreatedDate"]);
                }
            }
            return laser;
        }

        public int Update(ProductDto model)
        {
            var paras = new SqlParameter[9];
            paras[0] = new SqlParameter("@Rs", SqlDbType.Int) { Direction = ParameterDirection.Output };
            paras[1] = new SqlParameter("@PKID", model.PKID);
            paras[2] = new SqlParameter("@CategoryID", model.CategoryID);
            paras[3] = new SqlParameter("@ProductCode", model.ProductCode);
            paras[4] = new SqlParameter("@ProductName", model.ProductName);
            paras[5] = new SqlParameter("@Image", model.Image);
            paras[6] = new SqlParameter("@Price", model.Price);
            paras[7] = new SqlParameter("@Quantity", model.Quantity);
            paras[8] = new SqlParameter("@IsActive", model.IsActive);
            var rs = _db.Execute_Modify("Product_Update", paras, CommandType.StoredProcedure);
            if (rs > 0) return (int)paras[0].Value;
            return rs;
        }
    }
}
