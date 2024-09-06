using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {

        public async Task<IActionResult> Index()
        {
            var products = new List<ProductDTO>();

            using (HttpClient httpClient = new())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7033/api/Product/GetProducts"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();

                        // JSON verisini deserialize ederken hata yakalama
                        try
                        {
                            products = JsonSerializer.Deserialize<List<ProductDTO>>(apiResponse) ?? new List<ProductDTO>();
                        }
                        catch (JsonException ex)
                        {
                            // JSON parse hatası
                            return BadRequest($"JSON parse hatası: {ex.Message}");
                        }
                    }
                    else
                    {
                        return BadRequest("API çağrısı başarısız oldu.");
                    }
                }
            }

            return View(products);
        }




    }
}
