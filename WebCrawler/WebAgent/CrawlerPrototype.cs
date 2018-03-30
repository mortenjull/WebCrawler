using System;
using System.Collections.Generic;
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

        public async Task<HashSet<string>> CrawlASite(string site)
        {
            HashSet<string> links = new HashSet<string>();

            if (string.IsNullOrWhiteSpace(site))
            {
                links.Add("Bad site");
                return links;
            }
                

            try
            {
                var source = await BrowsingContext.New(this._configuration).OpenAsync(site);

                var list = source.QuerySelectorAll("a");
                
                foreach (var link in list)
                {
                    links.Add(link.GetAttribute("href")); 
                }
                return links;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("");
                links.Add("Could not crawl site");
                return links;
            }
        }
    }
}
