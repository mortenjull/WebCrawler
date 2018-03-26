using System;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Extensions;
using AngleSharp.Parser.Html;

namespace WebAgent
{
    public class CrawlerPrototype
    {
        private readonly IConfiguration _configuration;

        public CrawlerPrototype()
        {
            this._configuration = Configuration.Default.WithDefaultLoader();
        }

        public async Task<string> CrawlASite(string site)
        {
            if (string.IsNullOrWhiteSpace(site))
                return "Bad site";

            try
            {
                var source = await BrowsingContext.New(this._configuration).OpenAsync(site);

                var list = source.QuerySelectorAll("a");

                string stringlist = "";

                foreach (var link in list)
                {
                    stringlist += link.GetAttribute("href") + "\n";
                }
                return stringlist;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("");
                return "Could not crawl site";
            }
        }
    }
}
