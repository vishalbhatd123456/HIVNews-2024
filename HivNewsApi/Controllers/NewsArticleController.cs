using Microsoft.AspNetCore.Mvc;
using HivNewsApi.Models;
using System.Collections.Generic;

namespace HivNewsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewsArticleController
    {
        private static List<NewsArticle> _articles = new List<NewsArticle>
        {
            // Example article, you would fetch real data in a real scenario
            new NewsArticle { Id = 1, Title = "Latest HIV Cure Research", Content = "Details about the research...", PublishedDate = DateTime.Now, Source = "Science Daily" }
        };

        [HttpGet]
        public IEnumerable<NewsArticle> Get()
        {
            return _articles;
        }
    }
}