using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custodian.Salvage.Core.Helpers
{
    public static class DatabaseHelper
    {
        public static IDbConnection OpenDatabase(string connectionstring)
        {
            return new SqlConnection(connectionstring);
        }
    }
}
