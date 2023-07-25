using Microsoft.AspNetCore.Mvc;

namespace VLPMall.Controllers
{
	public class ApiController : Controller
	{
		private readonly HttpClient _httpClient;


		public ApiController(HttpClient httpClient)
        {
			_httpClient = httpClient;
		}

		public async Task<IActionResult> Index()
		{
			var response = await _httpClient.GetAsync("https://localhost:7125/api/Pokemon");
			var content = await response.Content.ReadAsStringAsync();

			return Ok(content);
		}
    }
}
