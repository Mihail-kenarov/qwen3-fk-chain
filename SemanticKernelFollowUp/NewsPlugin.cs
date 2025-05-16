using Microsoft.SemanticKernel;
using SimpleFeedReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemanticKernelFollowUp
{
    internal class NewsPlugin
    {
        [KernelFunction("get_news")]
        [Description("Get the news items for today")]
        [return: Description("A list of news items")]
        public List<FeedItem> GetNews(
              //Kernel kernel,
              [Description("The category provided in english")] string category
            )
        {
            var reader = new FeedReader();
            var feedItems = reader.RetrieveFeedAsync($"https://rss.nytimes.com/services/xml/rss/nyt/{category}.xml").Result;
            return feedItems.Take(5).ToList();
        }
    }
}
