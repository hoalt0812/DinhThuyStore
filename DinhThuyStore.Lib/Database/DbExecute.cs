using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinhThuyStore.Lib.Database
{
    public abstract class DbExecute
    {
        public abstract DataTable Execute_Table(string text, SqlParameter[] paras, CommandType cmdType);
        public abstract int Execute_Modify(string text, SqlParameter[] paras, CommandType cmdType);
        public abstract int Execute_Scalar(string text, SqlParameter[] paras, CommandType cmdType);
    }
}
