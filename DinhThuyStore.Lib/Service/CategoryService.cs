using DinhThuyStore.Lib.Database;
using DinhThuyStore.Lib.Dtos;
using DinhThuyStore.Lib.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinhThuyStore.Lib.Service
{
    public class CategoryService : CategoryInterface
    {
        private readonly DbExecute _db;

        public CategoryService()
        {
            _db = new SqlExecute();
        }

        public bool CheckCategoryName(string categoryName)
        {
            var paras = new SqlParameter[1];
            paras[0] = new SqlParameter("@CategoryName", categoryName);
            var rs = _db.Execute_Table("Category_GetByCategoryName", paras, CommandType.StoredProcedure);
            if (rs.Rows.Count > 0)
            {
                return false;
            }
            return true;
        }

        public int Create(CategoryDto model)
        {
            var paras = new SqlParameter[2];
            paras[0] = new SqlParameter("@Rs", SqlDbType.Int) { Direction = ParameterDirection.Output };
            paras[1] = new SqlParameter("@CategoryName", model.CategoryName);
            var rs = _db.Execute_Modify("Category_Insert", paras, CommandType.StoredProcedure);
            if (rs > 0) return (int)paras[0].Value;
            return rs;
        }

        public int Delete(int id)
        {
            var paras = new SqlParameter[2];
            paras[0] = new SqlParameter("@Rs", SqlDbType.Int) { Direction = ParameterDirection.Output };
            paras[1] = new SqlParameter("@PKID", id);
            var rs = _db.Execute_Modify("Category_Delete", paras, CommandType.StoredProcedure);
            if (rs > 0) return (int)paras[0].Value;
            return rs;
        }

        public List<CategoryDto> GetAll()
        {
            List<CategoryDto> list = new List<CategoryDto>();
            var dt = _db.Execute_Table("Category_GetAll", null, CommandType.StoredProcedure);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CategoryDto category = new CategoryDto();
                    category.PKID = Convert.ToInt32(dt.Rows[i]["PKID"]);
                    category.CategoryName = dt.Rows[i]["CategoryName"].ToString();
                    category.CreatedDate = Convert.ToDateTime(dt.Rows[i]["CreatedDate"]);
                    list.Add(category);
                }
            }
            return list;
        }

        public CategoryDto GetByPKID(int id)
        {
            var laser = new CategoryDto();
            var paras = new SqlParameter[1];
            paras[0] = new SqlParameter("@PKID", id);
            var tb = _db.Execute_Table("Category_GetByPKID", paras, CommandType.StoredProcedure);
            if (tb != null)
            {
                if (tb.Rows.Count > 0)
                {
                    laser.PKID = Convert.ToInt32(tb.Rows[0]["PKID"]);
                    laser.CategoryName = tb.Rows[0]["CategoryName"].ToString();
                    laser.CreatedDate = Convert.ToDateTime(tb.Rows[0]["CreatedDate"]);
                }
            }
            return laser;
        }

        public int Update(CategoryDto model)
        {
            var paras = new SqlParameter[3];
            paras[0] = new SqlParameter("@Rs", SqlDbType.Int) { Direction = ParameterDirection.Output };
            paras[1] = new SqlParameter("@PKID", model.PKID);
            paras[2] = new SqlParameter("@CategoryName", model.CategoryName);
            var rs = _db.Execute_Modify("Category_Update", paras, CommandType.StoredProcedure);
            if (rs > 0) return (int)paras[0].Value;
            return rs;
        }
    }
}
