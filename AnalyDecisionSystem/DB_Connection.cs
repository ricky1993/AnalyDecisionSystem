using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AnalyDecisionSystem
{
    class DB
    {
        public SqlConnection thisSqlconnection;
        public SqlTransaction Sqltran;
        public SqlCommand Sqlcmd;
        public DB()
        {
            string connStr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            thisSqlconnection = new SqlConnection(connStr);
            thisSqlconnection.Open();
        }
    }
}
