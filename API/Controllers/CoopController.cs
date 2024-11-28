using Core.Dtos;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoopController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = new List<ProductDto>();

            string url = "https://www.coop.se/globalt-sok/?query=salt";
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string htmlContent = await response.Content.ReadAsStringAsync();

            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(htmlContent);

            var nodes = document.DocumentNode.SelectNodes("//html/body/main/div/div");
            //var nodes = document.DocumentNode.SelectNodes("//html/body/main/div/div/div[4]/div/div/article");

            //if (nodes != null)
            //{
            //    result = specificNode.InnerHtml;
            //}
            //else
            //{
            //    result = "Node not found.";
            //}

            return Ok(result);
        }
    }
}
