using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace HTML_Parser_WinForm
{
    class ScraperSubCategories
    {
        static string URL = "http:";
        static List<ProductModel> catalog = new List<ProductModel>();


        public List<ProductModel> ScrapeData(string page)
        {
            var web = new HtmlWeb();

            var subdoc = web.Load(page);
            catalog.Clear();

            var subArticles = subdoc.DocumentNode.SelectNodes("//div[@class='portal-group']/div[@class='primary']/h2/a");

            if (subArticles != null)
                foreach (var subarticle in subArticles)
                {
                    var subtitle = HttpUtility.HtmlDecode(subarticle.Attributes["title"].Value);
                    var subhref = HttpUtility.HtmlDecode(subarticle.Attributes["href"].Value);

                        catalog.Add(new ProductModel { Title = subtitle, Url = URL + subhref });
                }

            subArticles = subdoc.DocumentNode.SelectNodes("//ul[@class='secondary']/li/h2/a");

            if (subArticles != null)
                foreach (var subarticle in subArticles)
                {
                    var subtitle = HttpUtility.HtmlDecode(subarticle.Attributes["title"].Value);
                    var subhref = HttpUtility.HtmlDecode(subarticle.Attributes["href"].Value);

                        catalog.Add(new ProductModel { Title = subtitle, Url = URL + subhref });
                }
            return catalog;
        }
        public bool CheckSubCategories(string page)
        {
            var web = new HtmlWeb();
            var doc = web.Load(page);

            var subArticles = doc.DocumentNode.SelectNodes("//div[@class='portal-group']/div[@class='primary']/h2/a");
            var subArticles1 = doc.DocumentNode.SelectNodes("//ul[@class='secondary']/li/h2/a");

            if (subArticles != null || subArticles1 != null)
            {
                return true;
            }

            return false;
        }
    }
}

