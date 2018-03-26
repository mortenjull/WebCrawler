using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAgent;

namespace WebCrawler
{
    public class Opperations
    {
        private readonly CrawlerPrototype _crawlerPrototype;

        public Opperations()
        {
            this._crawlerPrototype = new CrawlerPrototype();
        }

        public async void Crawl()
        {
            Console.WriteLine("Enter site to crawl:");
            var site = Console.ReadLine();

            var result = await _crawlerPrototype.CrawlASite(site);

            Console.WriteLine(result);
        }

        public void CrawlForSubDomains(string address)
        {


        }
    }
}
