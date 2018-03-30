using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAgent;

namespace WebCrawler
{
    public class Opperations
    {
        private readonly CrawlLinks _crawler;

        public Opperations()
        {
            this._crawler = new CrawlLinks();
        }

        public async void Crawl()
        {
            Console.WriteLine("Enter site to crawl:");
            var site = Console.ReadLine();

            var result = _crawler.StartCrawling(site);

            foreach (var link in result)
            {
                Console.WriteLine(link);
            }
        }

        public void CrawlForSubDomains(string address)
        {


        }
    }
}
