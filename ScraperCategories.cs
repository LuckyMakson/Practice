using HtmlAgilityPack;
using System.Collections.Generic;
using System.Web;

namespace HTML_Parser_WinForm
{
    class ScraperCategories
    {
        string URL = "http:";
        static List<EntryModel> catalog = new List<EntryModel>();


        public List<EntryModel> ScrapeData(string page)
        {
            var web = new HtmlWeb();
            var doc = web.Load(page);

            var Articles = doc.DocumentNode.SelectNodes("//div/ul[@class='catalog-categories-list']/li/a");

            foreach (var article in Articles)
            {
                var title = HttpUtility.HtmlDecode(article.SelectSingleNode("//p/text()").InnerText.Trim());
                var href = HttpUtility.HtmlDecode(article.Attributes["href"].Value);

                if (!href.Equals("//allo.ua/ru/xiaomi-page/") && !href.Equals("//allo.ua/ru/aksessuary-apple/")) 
                    catalog.Add(new EntryModel { Title = title, Url = URL + href });
            }
            return catalog;
        }
    }
}
