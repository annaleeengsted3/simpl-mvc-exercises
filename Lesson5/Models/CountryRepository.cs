using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Lesson5.Models
{
    public class CountryRepository
    {


        private List<Country> countries = new List<Country> {
new Country { Name = "China", CountryCode = "CN" },
new Country { Name = "Denmark", CountryCode = "DK" },
new Country { Name = "France", CountryCode = "FR" },
new Country { Name = "USA", CountryCode = "US" },
new Country { Name = "Germany", CountryCode = "DE" }
};
        public IEnumerable<Country> Countries { get { return countries; } }
        // Or alternatively you could use an expression-bodied get statement
        // public IEnumerable<Country> Countries => countries;
        public List<Country> CountriesSorted { get { return countries.OrderBy(x => x.Name).ToList(); } }
        public void AddCountry(Country newCountry)
        {
            // test for duplicates
            Country country = countries.Where(c => c.Name == newCountry.Name).FirstOrDefault();
            // add to the list if no duplicate exists
            if (country == null)
            {
                countries.Add(newCountry);
            }
        }




    }
}
