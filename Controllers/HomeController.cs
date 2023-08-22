using Microsoft.AspNetCore.Mvc;
using RestCountriesApi.Models;
using RestCountriesApi.Repositories.Abstraction;
using System.Diagnostics;

namespace RestCountriesApi.Controllers
{
	public class HomeController : Controller
	{
		private readonly ICountryApiService _countryApiService;
		

		public HomeController(ICountryApiService countryApiService)
		{
			_countryApiService = countryApiService;
		}

		public async Task<IActionResult> Countries()
		{
			List<Class1> countries = new List<Class1>();
			countries = await _countryApiService.GetCountries();

			 return View(countries);
		}
	}
}