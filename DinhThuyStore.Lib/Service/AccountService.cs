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
    public class AccountService : AccountInterface
    {
        private readonly DbExecute _db;

        public AccountService()
        {
            _db = new SqlExecute();
        }

        public bool CheckUserName(string userName)
        {
            var paras = new SqlParameter[1];
            paras[0] = new SqlParameter("@UserName", userName);
            var rs = _db.Execute_Table("Account_GetByUserName", paras, CommandType.StoredProcedure);
            if (rs.Rows.Count > 0)
            {
                return false;
            }
            return true;
        }

        public int Create(AccountDto model)
        {
            var paras = new SqlParameter[5];
            paras[0] = new SqlParameter("@Rs", SqlDbType.Int) { Direction = ParameterDirection.Output };
            paras[1] = new SqlParameter("@FullName", model.FullName);
            paras[2] = new SqlParameter("@UserName", model.UserName);
            paras[3] = new SqlParameter("@Password", Common.Md5Endcoding(model.Password));
            paras[4] = new SqlParameter("@Role", model.Role);
            var rs = _db.Execute_Modify("Account_Insert", paras, CommandType.StoredProcedure);
            if (rs > 0) return (int)paras[0].Value;
            return rs;
        }

        public int Delete(int id)
        {
            var paras = new SqlParameter[2];
            paras[0] = new SqlParameter("@Rs", SqlDbType.Int) { Direction = ParameterDirection.Output };
            paras[1] = new SqlParameter("@PKID", id);
            var rs = _db.Execute_Modify("Account_Delete", paras, CommandType.StoredProcedure);
            if (rs > 0) return (int)paras[0].Value;
            return rs;
        }

        public List<AccountDto> GetAll()
        {
            List<AccountDto> list = new List<AccountDto>();
            var dt = _db.Execute_Table("Account_GetAll", null, CommandType.StoredProcedure);
            if (dt.Rows.Count > 0)
            {
                for(int i=0; i<dt.Rows.Count; i++)
                {
                    AccountDto account = new AccountDto();
                    account.PKID = Convert.ToInt32(dt.Rows[i]["PKID"]);
                    account.FullName = dt.Rows[i]["FullName"].ToString();
                    account.UserName = dt.Rows[i]["UserName"].ToString();
                    account.Password = dt.Rows[i]["Password"].ToString();
                    account.Role = dt.Rows[i]["Role"].ToString();
                    account.CreatedDate = Convert.ToDateTime(dt.Rows[i]["CreatedDate"]);
                    list.Add(account);
                }
            }
            return list;
        }

        public DataTable GetByUserNameAndPassword(string userName, string password)
        {
            AccountDto account = new AccountDto();
            var paras = new SqlParameter[2];
            paras[0] = new SqlParameter("@UserName", userName);
            paras[1] = new SqlParameter("@Password", Common.Md5Endcoding(password));
            return _db.Execute_Table("Account_GetByUserNameAndPassword", paras, System.Data.CommandType.StoredProcedure);
        }
    }
}
