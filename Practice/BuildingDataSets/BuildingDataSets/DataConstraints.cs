using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BuildingDataSets
{
    class DataConstraints
    {
        public static void Main(string[] args)
        {
            OurDataConstraints();
            Console.Read();
        }

        public static void OurDataConstraints()
        {
            DataSet ds = new DataSet();

            DataTable ClassTable = ds.Tables.Add("OurClass");

            ClassTable.Columns.Add("CId", typeof(int));
            ClassTable.Columns.Add("ClassName", typeof(string));


            DataTable StudentTable = ds.Tables.Add("Students");

            StudentTable.Columns.Add("SId", typeof(int));
            StudentTable.Columns.Add("ClassId", typeof(int));
            StudentTable.Columns.Add("SName", typeof(string));


            // initialize pk constraints


            ClassTable.PrimaryKey = new DataColumn[] { ClassTable.Columns["CId"] };
            // add the relation to the dataset

            ds.Relations.Add("classstudent",ClassTable.Columns["Cid"], StudentTable.Columns["ClassId"]);

            // to set the foreign key
            DataColumn dcclassid = ds.Tables["OurClass"].Columns["CId"];
            DataColumn dcstudentid = ds.Tables["Students"].Columns["ClassId"];

            ForeignKeyConstraint fkc = new ForeignKeyConstraint("csfkc", dcclassid,dcstudentid);

            //we can set the rules for foreign key
            fkc.DeleteRule = Rule.SetNull;
            fkc.UpdateRule = Rule.Cascade;

            // we can add a unique constraints
            UniqueConstraint ucnames = new UniqueConstraint(new DataColumn[] { ClassTable.Columns["ClassName"] });

            ds.Tables["OurClass"].Constraints.Add(ucnames);

            // now we can test it by giving data to rows

            DataRow dr1 = ds.Tables["OurClass"].NewRow();

            dr1["CId"] = 1;
            dr1["ClassName"] = null;

            ClassTable.Rows.Add(dr1);

            dr1 = ds.Tables["OurClass"].NewRow();

            dr1["CId"] = 2;
            dr1["ClassName"] = "sixth";
            ClassTable.Rows.Add(dr1);


            dr1 = ds.Tables["OurClass"].NewRow();


            dr1["CId"] = 3;
            dr1["ClassName"] = "seventh";
            ClassTable.Rows.Add(dr1);

            // add data to the students table


            DataRow dr2 = ds.Tables["Students"].NewRow();
            dr2["ClassId"] = 4;
            dr2["SId"] = 1;
            dr2["Sname"] = "Infinite";

            StudentTable.Rows.Add(dr2);




        }
    }
}
