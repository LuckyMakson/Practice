using HtmlAgilityPack;
using System.Collections.Generic;
using System.Web;

namespace HTML_Parser_WinForm
{
	class ScraperProducts
	{
		static List<EntryModel> products = new List<EntryModel>();
		static string URL = "http:";

		public List<EntryModel> ScrapeData(string page)
		{
			var web = new HtmlWeb();
			page += "/p-";
			for (int i = 1; i < 2; i++)
			{
				var doc = web.Load(page + i);

				var Articles = doc.DocumentNode.SelectNodes("//ul[@class='products-grid']/li/div/div/div[@class='product-name-container']/a");
				if (Articles == null)
					return products;

				foreach (var article in Articles)
				{
					var title = HttpUtility.HtmlDecode(article.Attributes["title"].Value);
					var href = HttpUtility.HtmlDecode(article.Attributes["href"].Value);
					products.Add(new EntryModel { Title = title, Url = URL + href });
				}
			}
			return products;
		}
	}
}
