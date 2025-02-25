﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ADO
{
    class Program
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        static SqlConnection getConnection()
        {
            con = new SqlConnection("Data Source=ICS-LT-GSRQ4D3;Initial Catalog=assesment;" +
                "Integrated Security=true;");
            con.Open();
            return con;
        }

        static void ProductDetail()
        {
            con = getConnection();
            cmd = new SqlCommand("InsertAndRet", con);
            cmd.CommandType = CommandType.StoredProcedure;

            Console.Write("Enter the product name:");
            string prdName = Console.ReadLine();

            Console.Write("\nEnter the product price:");
            int prdPrice = Convert.ToInt32(Console.ReadLine());


            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "@ProductName";
            param1.Value = prdName;
            param1.DbType = DbType.String;
            param1.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param1);

            SqlParameter param2 = new SqlParameter();
            param2.ParameterName = "@Price";
            param2.Value = prdPrice;
            param2.DbType = DbType.Int32;
            param2.Direction = ParameterDirection.Input;

            cmd.Parameters.Add(param2);

            SqlDataReader dr = cmd.ExecuteReader();
            Console.WriteLine("\n==========Result===========\n");
            Console.WriteLine("ProductName\tProductPrice\tDiscountPrice");
            while (dr.Read())
            {
                Console.WriteLine(dr[0] + "\t" + dr[1] +"\t" + dr[2] + dr[3]);
            }
        }
        static void Main(string[] args)
        {
            ProductDetail();
            Console.Read();
        }
    }
}