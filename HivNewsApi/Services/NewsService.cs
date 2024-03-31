using System.Net.Http;
using System.Threading.Tasks;
using HivNewsApi.Models;
using System.Text.Json;
using System.Collections.Generic;

namespace HivNewsApi.Services
{
    public class NewsService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "YOUR_API_KEY"; //keep this in Param store in future
        private readonly string _baseUrl = "https://newsapi.org/v2/everything";

        public NewsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<NewsArticle>> GetLatestHivNewsAsync()
        {
            var url = $"{_baseUrl}?q=HIV&sortBy=publishedAt&apiKey={_apiKey}"; // fetch the hiv related dta records from the millions in the news api.
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var newsResponse = JsonSerializer.Deserialize<NewsAApiResponse>(content);

            var articles = new List<NewsArticle>();
            foreach(var article in newsResponse.Articles)
            {
                articles.Add(new NewsArticle
                {
                    Title = article.Title,
                    Content = article.Description,
                    PublishedDate = article.PublishedAt,
                    Source = article.Source.Name
                });
            }
            return articles;
        }
        private class NewsAApiResponse
        {
            public List<Article> Articles{get;set;}
        }
        private class Article
        {
            public string Title{get;set;}
            public string Description{get;set;}
            public DateTime PublishedAt{get;set;}
            public Source Source{get;set;}
        }

        private class Source
        {
            public string Name{get;set;}
        }

    }

}