using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BuildingDataSets
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. let us create an in-memory cache


            DataSet dsEmployment = new DataSet("Employment");


            // 2. Now add Data Table 

            DataTable dtEmployee = new DataTable("Employees");

            // 3. Define columns to the table

            DataColumn[] dcEmployee = new DataColumn[4];


            // 4. Add column details in terms of name,type and size
            dcEmployee[0] = new DataColumn("EmpCode", System.Type.GetType("System.Int32"));
            dcEmployee[1] = new DataColumn("EmpName",System.Type.GetType("System.String"));
            dcEmployee[2] = new DataColumn("EmpDept", System.Type.GetType("System.String"));
            dcEmployee[3] = new DataColumn("EmpStatusID", System.Type.GetType("System.Int32"));


            //5. Add the above columns to the data table

            dtEmployee.Columns.Add(dcEmployee[0]);
            dtEmployee.Columns.Add(dcEmployee[1]);
            dtEmployee.Columns.Add(dcEmployee[2]);
            dtEmployee.Columns.Add(dcEmployee[3]);

            // 6. Now add rows with data

            DataRow drEmpRows = dtEmployee.NewRow();
            drEmpRows["EmpCode"] = "1";
            drEmpRows["EmpName"] = "Renuka";
            drEmpRows["EmpDept"] = "IT";
            drEmpRows["EmpStatusID"] = "1";

            // 7. Add the above to the data table

            dtEmployee.Rows.Add(drEmpRows);


            // repeat step 6 and 7 for the number of rows you want
            drEmpRows = dtEmployee.NewRow();

            drEmpRows["EmpCode"] = "2";
            drEmpRows["EmpName"] = "Rajesh";
            drEmpRows["EmpDept"] = "Finance";
            drEmpRows["EmpStatusID"] = "4";


            dtEmployee.Rows.Add(drEmpRows);
            drEmpRows = dtEmployee.NewRow();

            drEmpRows["EmpCode"] = "3";
            drEmpRows["EmpName"] = "Som";
            drEmpRows["EmpDept"] = "ITsupport";
            drEmpRows["EmpStatusID"] = "3";


            dtEmployee.Rows.Add(drEmpRows);
            drEmpRows = dtEmployee.NewRow();


            drEmpRows["EmpCode"] = "4";
            drEmpRows["EmpName"] = "Sekar";
            drEmpRows["EmpDept"] = "Finance";
            drEmpRows["EmpStatusID"] = "1";


            dtEmployee.Rows.Add(drEmpRows);
            drEmpRows = dtEmployee.NewRow();

            drEmpRows["EmpCode"] = "5";
            drEmpRows["EmpName"] = "Durga";
            drEmpRows["EmpDept"] = "ITSupport";
            drEmpRows["EmpStatusID"] = "3";


            dtEmployee.Rows.Add(drEmpRows);
            drEmpRows = dtEmployee.NewRow();


            drEmpRows["EmpCode"] = "1";
            drEmpRows["EmpName"] = "Sai";
            drEmpRows["EmpDept"] = "Finance";
            drEmpRows["EmpStatusID"] = "4";


            dtEmployee.Rows.Add(drEmpRows);

            // 8. create another table

            DataTable dtEmpStatus = new DataTable("EmployeeStatus");

            // 9. Create columns for the second table

            DataColumn[] dcStatus = new DataColumn[2];
            dcStatus[0] = new DataColumn("EmpStatusID",System.Type.GetType("System.Int32"));
            dcStatus[1] = new DataColumn("EmpStatus",System.Type.GetType("System.String"));

            //10. 

            dtEmpStatus.Columns.Add(dcStatus[0]);
            dtEmpStatus.Columns.Add(dcStatus[1]);

            // 11. Rows for the table

            DataRow drStatusRow = dtEmpStatus.NewRow();

            // 12. Give values

            drStatusRow["EmpStatusID"] = "1";
            drStatusRow["EmpStatus"] = "Full Time";

            dtEmpStatus.Rows.Add(drStatusRow);

            
            drStatusRow = dtEmpStatus.NewRow();
            
            drStatusRow["EmpStatusID"] = "2";
            drStatusRow["EmpStatus"] = "Part Time";

            dtEmpStatus.Rows.Add(drStatusRow);
            drStatusRow = dtEmpStatus.NewRow();


            drStatusRow["EmpStatusID"] = "3";
            drStatusRow["EmpStatus"] = "Contract";

            dtEmpStatus.Rows.Add(drStatusRow);
            drStatusRow = dtEmpStatus.NewRow();


            drStatusRow["EmpStatusID"] = "4";
            drStatusRow["EmpStatus"] = "Interns";

            dtEmpStatus.Rows.Add(drStatusRow);

            // 13. add the 2 tables to dataset

            dsEmployment.Tables.Add(dtEmployee);
            dsEmployment.Tables.Add(dtEmpStatus);


            // 14. Associating 2 tables

            // 14.1 Primary and Foreign key setting

            DataColumn parent = dsEmployment.Tables["EmployeeStatus"].Columns["EmpStatusID"];
            DataColumn child = dsEmployment.Tables["Employees"].Columns["EmpStatusID"];

            // 14.2 set the relation

            DataRelation emprel1 = new DataRelation("EmpStatusRelation",parent,child);

            //14.3 adding the datarelation to the dataset
            dsEmployment.Relations.Add(emprel1);


            // 15. Now lets Display the data as per the relation

            Console.WriteLine("===========================================================================");
            Console.WriteLine("Status ID          |             Employee Status     |");
            Console.WriteLine("===========================================================================");
            foreach (DataRow row in dsEmployment.Tables["Employees"].Rows)
            {
                Console.WriteLine("{0}                  |                     {1}", row["EmpStatusID"], row["EmpStatus"]);
                Console.WriteLine("===========================================================================");
                Console.WriteLine("EmpCode             |        EmpName            +              Department | ");
                Console.WriteLine("===========================================================================");
            }  

                foreach(DataRow row in dsEmployment.Tables["Employees"].Rows)
                {
                //Console.WriteLine("{0}                  |       {1}                 |           {2}         |           {3}             |           {4}            ",row["Empid"],row["EmpName"],row["EmpDept"],row["EmpStatusID"]);

                // for getting the status as a string info

                int irow = int.Parse(row["EmpStatusID"].ToString());

                DataRow currentrow = dsEmployment.Tables["EmployeeStatus"].Rows[irow - 1];
                Console.WriteLine("{0}                  |       {1}                 |           {2}         |           {3}             |           {4}            ",row["Empcode"],row["EmpName"],row["EmpDept"],currentrow["EmpStatus"]);

            }

            Console.Read();









        }
    }
}
