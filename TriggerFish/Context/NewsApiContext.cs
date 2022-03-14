using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewsAPI;
using NewsAPI.Models;
using NewsAPI.Constants;
using System.Configuration;
using TriggerFish.Models;
using RestSharp;

namespace TriggerFish.Context
{
    /// <summary>
    /// Get News feed from News API
    /// https://newsapi.org/
    /// </summary>
    public class NewsApiContext
    {
        public List<NewsArticle> GetNewsFeed()
        {
            List<NewsArticle> newsArticles = new List<NewsArticle>();
            var newsApiClient = new NewsApiClient(ConfigurationManager.AppSettings["NewsApiKey"]);
            var articlesResponse = newsApiClient.GetEverything(new EverythingRequest
            {
                Q = "Ukraine",
                SortBy = SortBys.Popularity,
                Language = Languages.EN,
                From = new DateTime(2022, 3, 14), 
                PageSize= 3
            });
            if (articlesResponse.Status == Statuses.Ok)
            {
                //foreach (var article in articlesResponse.Articles)
                //{
                //    var newsArticle = new NewsArticle
                //    {
                //        Title = article.Title,
                //        Description = article.Description,
                //        ImageUrl = article.UrlToImage,
                //        Url = article.Url,
                //        ReadTime = new Random().Next(10)
                //    };
                //    newsArticles.Add(newsArticle);
                //}
                return newsArticles;
            }
            else
            {
                return null;
            }
        }

        public List<NewsArticle> GetNewsFeed1()
        {
            List<NewsArticle> newsArticles = new List<NewsArticle>();

            RestClient client = GetClient("https://newsapi.org/v2/everything");
            RestRequest request = GetRequestWithDefaultHeaders(new RestRequest());
            request.AddQueryParameter("apiKey", ConfigurationManager.AppSettings["NewsApiKey"]);
            request.AddQueryParameter("pageSize", 3);
            request.AddQueryParameter("SortBy", 0);
            request.AddQueryParameter("From", DateTime.Now.ToString("yyyy-MM-dd"));
            request.AddQueryParameter("q", "Ukraine");
            var response = client.GetAsync(request).Result;
            Random random = new Random();
            ArticlesResult articleResult = Newtonsoft.Json.JsonConvert.DeserializeObject<ArticlesResult>(response.Content);
            if (articleResult != null)
            {
                foreach (var article in articleResult.Articles)
                {
                    var newsArticle = new NewsArticle
                    {
                        Title = article.Title,
                        Description = article.Description,
                        ImageUrl = article.UrlToImage,
                        Url = article.Url,
                        ReadTime = random.Next(1,9)
                    };
                    newsArticles.Add(newsArticle);
                }
            }
            return newsArticles;
        }

        public RestClient GetClient(string url)
        {
            var clientOptions = new RestClientOptions(url)
            {
                Timeout = -1
            };
            var client = new RestClient(clientOptions);
            return client;
        }
        public RestRequest GetRequestWithDefaultHeaders(RestRequest request)
        {
            request.AddHeader("Accept", "application/json");
            return request;
        }


    }
}