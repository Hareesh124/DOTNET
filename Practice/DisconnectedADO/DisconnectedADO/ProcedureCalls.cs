using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Transactions;
using System.Data;

namespace DisconnectedADO
{
    class ProcedureCalls
    {
    
        static void Main(string[] args)
        {
            using (SqlConnection con = new SqlConnection("Data Source = ICS-LT-GSRQ4D3;database = northwind;trusted_connection=true"))
            {
                using (SqlCommand cmd = new SqlCommand("sp_getsalary", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ename", SqlDbType.VarChar, 20)).Value = "AdiSiva";

                    SqlParameter param = new SqlParameter("@salary", SqlDbType.Float);
                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteScalar();
                    int sal = Convert.ToInt32(cmd.Parameters["@salary"].Value);
                    Console.WriteLine("Salary : " + sal);

                    Console.Read();
                }
            }
        }

    }
}
