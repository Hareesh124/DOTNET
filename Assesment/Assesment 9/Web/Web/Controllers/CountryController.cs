using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
   
        // GET: Country
        public class CountryController : ApiController
        {
            static List<Country> countries = new List<Country>
            {
            new Country { ID = 1, CountryName = "England", Capital = "London" },
            new Country { ID = 2, CountryName = "India", Capital = "New Delhi" }
            };

            public IEnumerable<Country> Get()
            {
                return countries;
            }

            public IHttpActionResult Get(int id)
            {
                var country = countries.FirstOrDefault(c => c.ID == id);
                if (country == null)
                {
                    return NotFound(); 
                }

                return Ok(country); 
            }

            // POST
            public IHttpActionResult Post([FromBody] Country country)
            {
                if (country == null)
                {
                    return BadRequest("Invalid data.");
                }

                country.ID = countries.Max(c => c.ID) + 1;

                countries.Add(country);
                return CreatedAtRoute("DefaultApi", new { id = country.ID }, country); 
            }

            // PUT
            public IHttpActionResult Put(int id, [FromBody] Country updatedCountry)
            {
                var existingCountry = countries.FirstOrDefault(c => c.ID == id);
                if (existingCountry == null)
                {
                    return NotFound(); 
                }

                existingCountry.CountryName = updatedCountry.CountryName;
                existingCountry.Capital = updatedCountry.Capital;

                return Ok(existingCountry); 
            }

            // DELETE
            public IHttpActionResult Delete(int id)
            {
                var country = countries.FirstOrDefault(c => c.ID == id);
                if (country == null)
                {
                    return NotFound(); 
                }

                countries.Remove(country);
                return Ok(); 
            }
        }
}