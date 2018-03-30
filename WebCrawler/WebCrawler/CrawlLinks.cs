using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAgent;

namespace WebCrawler
{
    public class CrawlLinks
    {
        private CrawlerPrototype _crawler;

        private HashSet<string> _crawledSites;
        private BlockingCollection<string> _gatheredSites;

        public CrawlLinks()
        {
            this._crawler = new CrawlerPrototype();

            this._crawledSites = new HashSet<string>();
            this._gatheredSites = new BlockingCollection<string>();
        }

        public HashSet<string> StartCrawling(string homepage)
        {
            this._gatheredSites.Add(homepage);
            
            //while (true)
            //{
                Task.Run(async() =>
                {
                    string site = this._gatheredSites.Take();
                    if (!_crawledSites.Contains(site))
                    {
                        HashSet<string> links = await this._crawler.CrawlASite(site);

                        foreach (var link in links)
                        {
                            this._gatheredSites.Add(link);
                        }

                        this._crawledSites.Add(site);
                    }
                    
                });
                Console.WriteLine($"Items in BlockingCollection: {_gatheredSites.Count}");
                Console.WriteLine($"Items in CrawledSites: {_crawledSites.Count}");
            //}

            return _crawledSites;
        }

        private void StartNewCrawling()
        {
            if (_gatheredSites.Count == 0)
                return;

            try
            {
                var link = _gatheredSites.Take();


            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
