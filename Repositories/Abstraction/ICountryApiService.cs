using RestCountriesApi.Models;

namespace RestCountriesApi.Repositories.Abstraction
{
	public interface ICountryApiService
	{
		Task<List<Class1>> GetCountries();
	}
}
