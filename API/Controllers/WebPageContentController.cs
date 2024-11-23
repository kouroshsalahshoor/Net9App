using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebPageContentController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = string.Empty;

            string url = "https://google.com";
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string htmlContent = await response.Content.ReadAsStringAsync();

            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(htmlContent);

            var specificNode = document.DocumentNode.SelectSingleNode("//title");
            //var specificNode = document.DocumentNode.SelectSingleNode("//div[@class='specific-class']");

            if (specificNode != null)
            {
                result = specificNode.InnerHtml;
            }
            else
            {
                result = "Node not found.";
            }

            return Ok(result);
        }
    }
}
