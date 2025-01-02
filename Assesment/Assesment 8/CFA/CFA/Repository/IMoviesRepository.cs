using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CFA.Repository
{
    public class IMoviesRepository<T> where T : class
    {
        IEnumerable<T> GetAll();  //get all products
        T GetById(object Id);  // to get a particular product based on id
        void Insert(T obj);
        void Update(T obj);
    }
}