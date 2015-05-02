using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DependencyElimination
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			var sw = Stopwatch.StartNew();
		    Action<string> logger = (Console.WriteLine);
		    IEnumerable<string> urls = GetUrls();
		    IEnumerable<string> links = GetAllLinks(urls, logger);
		    File.WriteAllLines("links.txt", links);
			Console.WriteLine("Finished");
			Console.WriteLine(sw.Elapsed);
		}

	    private static IEnumerable<string> GetUrls()
	    {
             for (int page = 1; page < 6; page++)
                yield return ("http://habrahabr.ru/top/page" + page);
	    }

	    private static IEnumerable<string> GetAllLinks(IEnumerable<string> urls, Action<string> logger = null)
	    {
	        if (logger == null) logger = delegate(string s) { };
	        var allLinks = new List<string>();
            foreach (var url in urls)
            {
                logger("url: " + url);
                string[] links;
                string errorMessage;
                if (GetLinksFromUrl(url, out links, out errorMessage))
                {
                    logger("found links: " + links.Count());
                    allLinks.AddRange(links);
                }
                else
                {
                    logger(errorMessage);
                }
            }
            logger("Total links found: " + allLinks.Count);
            return allLinks;
	    }
        
	    private static bool GetLinksFromUrl(string url, out string[] links, out string errorMessage)
	    {

	        string content;
	        if (GetContent(url, out content, out errorMessage))
	        {
	            links = GetLinksFromContent(content);
	            return true;
	        }
	        else
	        {
	            links = new string[0];
	            return false;
	        }
	    }

	    private static string[] GetLinksFromContent(string content)
	    {
            var matches = Regex.Matches(content, @"\Whref=[""'](.*?)[""'\s>]").Cast<Match>();
            return matches.Select(match => match.Groups[1].Value).ToArray();
	    }

	    private static bool GetContent(string url, out string content, out string errorMessage)
	    {
	        using (var http = new HttpClient())
	        {
                var response = http.GetAsync(url).Result;
	            if (response.IsSuccessStatusCode)
	            {
	                errorMessage = null;
	                content = response.Content.ReadAsStringAsync().Result;
	                return true;
	            }
	            else
	            {
	                errorMessage = "Error: " + response.StatusCode + " " + response.ReasonPhrase;
	                content = null;
	                return false;
	            }
	        }
	    }
	}
}