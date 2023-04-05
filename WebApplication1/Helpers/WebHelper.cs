using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using HtmlAgilityPack;
using WebApplication1.Models;

namespace WebApplication1.Helpers
{
    public static class WebHelper
    {
        public static List<string> GetImageUrls(HtmlDocument doc)
        {
            List<string> images = new List<string>();
            var imageUrls = doc.DocumentNode.Descendants("img").Select(e => e.GetAttributeValue("src", null)).Where(s => !String.IsNullOrEmpty(s));
            if (imageUrls != null && imageUrls.Any())
            {
                images = imageUrls.ToList();
            }
            return images;
        }

        public static Dictionary<string, int> GetAllWords(HtmlDocument doc)
        {
            var wordCounts = new Dictionary<string, int>();
            var textNodes = doc.DocumentNode.DescendantsAndSelf().Where(n => n.NodeType == HtmlNodeType.Text && !String.IsNullOrWhiteSpace(n.InnerText) && !(n.Name == "script" || n.Name == "style"));
            foreach (var node in textNodes)
            {
                var words = node.InnerText.Split(new[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.RemoveSpecialCharacters());
                foreach (var word in words)
                {
                    if (!string.IsNullOrEmpty(word))
                    {
                        if (wordCounts.ContainsKey(word))
                        {
                            wordCounts[word]++;
                        }
                        else
                        {
                            wordCounts[word] = 1;
                        }
                    }                    
                }
            }
            return wordCounts;
        }

        public static string RemoveSpecialCharacters(this string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
}