using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPooling
{
    class Employee
    {
        public static int objctr = 0;

        public string Fname { get; set; }
        public string Lname { get; set; }
        public int Eid { get; set; }
        public string Dept { get; set; }
        public Employee()
        {
            ++objctr;
        }
    }
    class Factory
    {
        // max objects req
        static int maxpoolsize = 3;

        //collection pool for our program
        static readonly Queue objpool = new Queue(maxpoolsize);

        public Employee GetEmployee()
        {
            Employee eobj;
            //check from the pool collections for an object
            //if exists return; else create a new object

            if(Employee.objctr >= maxpoolsize && objpool.Count > 0)
            {
                //retrieve object from pool
                eobj = RetrieveFromPool();
            }
            else
            {
                eobj = GetNewEmployee();
            }

            return eobj;
        }

        public Employee GetNewEmployee()
        {
            Employee e = new Employee();
            objpool.Enqueue(e);
            return e;
        }

        protected Employee RetrieveFromPool()
        {
            Employee e;
            // check if there any objects in the collection
            if(objpool.Count > 0)
            {
                e = (Employee)objpool.Dequeue();
                Employee.objctr--;
            }
            else
            {
                // return new object using
                e = GetEmployee();
            }
            return e;
        }
    }
    class ObjectPooling
    {
        static void Main(string[] args)
        {
            Factory factory = new Factory();
            Employee emp1 = factory.GetEmployee();
            Console.WriteLine("First Employee Object");
            Employee emp2 = factory.GetEmployee();
            Console.WriteLine("Second Employee Object");
            Employee emp3 = factory.GetEmployee();
            Console.WriteLine("Third Employee Object");
            
            // from the pool
            Employee emp4 = factory.GetEmployee();
            Console.WriteLine("Fourth Employee Object is pooled");
            Employee emp5 = factory.GetEmployee();
            Console.WriteLine("Fifth Employee Object");

            Console.Read();
        }
    }
}
