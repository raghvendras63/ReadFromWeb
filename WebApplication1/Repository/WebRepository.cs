using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Helpers;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class WebRepository : IWebRepository
    {
        public WebViewModel CreateViewModel(string url)
        {
            WebViewModel webViewModel = new WebViewModel();
            var doc = GetHtmlDocument(url);
            if (doc != null)
            {
                webViewModel.Images = WebHelper.GetImageUrls(doc);

                var totalWords = WebHelper.GetAllWords(doc);

                int totalWordCount = totalWords.Sum(pair => pair.Value);
                webViewModel.TotalWordCount = totalWordCount;

                var topWords = totalWords.OrderByDescending(pair => pair.Value).Take(10).ToList();
                webViewModel.TopTenWords = topWords;
            }            
            return webViewModel;
        }

        private HtmlDocument GetHtmlDocument(string url)
        {
            try
            {
                var web = new HtmlWeb();
                return web.Load(url);
            }
            catch
            {
                throw;
            }
        }

    }
}