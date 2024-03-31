namespace HivNewsApi.Models
{
    public class NewsArticle
    {
        public int Id {get;set;}
        public string Title{get;set;}
        public string Content {get;set;}
        public DateTime PublishedDate{get;set;}
        public string Source{get;set;}
    }
}