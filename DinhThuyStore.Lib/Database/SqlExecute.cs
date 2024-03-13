using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinhThuyStore.Lib.Database
{
    public class SqlExecute : DbExecute
    {
        private readonly string _connectionString;
        private SqlConnection _cnn;
        public SqlExecute()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"]?.ConnectionString;
        }
        public override int Execute_Modify(string text, SqlParameter[] paras, CommandType cmdType)
        {
            using (_cnn = new SqlConnection(_connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(text, _cnn) { CommandType = cmdType };
                    if (paras != null)
                        cmd.Parameters.AddRange(paras);

                    _cnn.Open();

                    return cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    //ManageLog.WriteErrorWeb(ex.Message + "\n" + text);
                    return -9;
                }
            }
        }

        public override int Execute_Scalar(string text, SqlParameter[] paras, CommandType cmdType)
        {
            using (_cnn = new SqlConnection(_connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(text, _cnn) { CommandType = cmdType };
                    if (paras != null)
                        cmd.Parameters.AddRange(paras);

                    _cnn.Open();

                    return (int)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    //ManageLog.WriteErrorWeb(ex.Message + "\n" + text);
                    return -9;
                }
            }
        }

        public override DataTable Execute_Table(string text, SqlParameter[] paras, CommandType cmdType)
        {
            using (_cnn = new SqlConnection(_connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(text, _cnn) { CommandType = cmdType };
                    if (paras != null)
                        cmd.Parameters.AddRange(paras);

                    DataTable table = new DataTable();
                    _cnn.Open();
                    table.Load(cmd.ExecuteReader());

                    return table;
                }
                catch (Exception ex)
                {
                    //ManageLog.WriteErrorWeb(ex.Message + "\n" + text);
                    return null;
                }
            }
        }
    }
}
