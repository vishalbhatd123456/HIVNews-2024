using Microsoft.AspNetCore.Mvc;
using HivNewsApi.Models;
using System.Collections.Generic;

namespace HivNewsApi.Controllers
{
        [ApiController]
        [Route("[controller]")]
        public class NewsArticleController
        {
            private readonly NewsService _newsService;
        }
        public NewsArticlesController(NewsService newsService)
        {
            _newsService = newsService;
        }

        [HttpGet]
        public async Task<IEnumerable<NewsArticle>> Get()
        {
            var articles = await _newsService.GetLatestHivNewsAsync();
            return articles;
        }
}