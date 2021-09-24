using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Lesson5.Models;


namespace Lesson5.Controllers
{
    public class Exercise01Controller : Controller
    {

        //private CountryRepository countryRepository = new CountryRepository();
        private CountryRepository countryRepository;
        private List<SelectListItem> countriesDropdown = new List<SelectListItem>();


        public Exercise01Controller(CountryRepository repo)
        {
            countryRepository = repo;
        }

        public IActionResult Index(string country)
        {
            int i = 12;
            string s = i.ToString();
            int l = s.Length;
            foreach (Country item in countryRepository.CountriesSorted)
            { // if there is a country parameter in the URL
                if (!String.IsNullOrEmpty(country))
                { // if the country from the countries List we're looking at right now has the same country code value given as the parameter
                    if (item.CountryCode == country)
                    {
                        // mark the SelectLisItem as seleced
                        countriesDropdown.Add(new SelectListItem { Text = item.Name, Value = item.CountryCode, Selected = true });
                    }
                    else
                    {
                        // otherwise it should not be marked as selected
                        countriesDropdown.Add(new SelectListItem { Text = item.Name, Value = item.CountryCode });
                    }
                }
                else
                {
                    // if no country parameter is given, no SelectLisItem should be marked as seleced
                    countriesDropdown.Add(new SelectListItem { Text = item.Name, Value = item.CountryCode });
                }
            }
            ViewBag.Countries = countriesDropdown;
            ViewData["Title"] = "Country";
            ViewBag.CountryCode = country;
            return View();
        }



        [HttpPost]
public IActionResult Index(Country newCountry) {
            // Add the new country to the repository 
            countryRepository.AddCountry(newCountry);
            // loop though the list for countries
            foreach (Country item in countryRepository.CountriesSorted)
            {
                // add new selectitem elements to the countriesDropdown list // make element selected if it is an element with newCountry ConutryCode
                if (item.CountryCode == newCountry.CountryCode)
                {
                    countriesDropdown.Add(new SelectListItem { Text = item.Name, Value = item.CountryCode, Selected = true });
                }
                else
                {
                    countriesDropdown.Add(new SelectListItem { Text = item.Name, Value = item.CountryCode });
                }
            }
            ViewBag.Countries = countriesDropdown;
            return View(newCountry);
        }

    }
}
