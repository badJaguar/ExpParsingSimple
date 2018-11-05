using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace ExpParsingSimple
{
    class Program
    {
        static void Main()
        {
        GetHtmlAsync();
            Console.ReadKey();
        }

        private static async void GetHtmlAsync()
        {
            var url = "https://www.6pm.com/adidas-originals/UgEBWgLSBuICAgsK.zso?s=goLiveDate/";
            using (var http = new HttpClient())
            {
                var html = await http.GetStringAsync(url);
                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(html);

                var listProduct = htmlDocument.DocumentNode.Descendants("div")
                    .Where(e=>e.GetAttributeValue("id", "")
                        .Equals("searchPage")).ToList();

                var items = listProduct[0].Descendants("article")
                    .Where(e => e.GetAttributeValue("class", "")
                        .Contains("_1h6Kf")).ToList();
                foreach (var item in items)
                {
                    //Console.WriteLine(item);
                    Console.WriteLine(item.InnerHtml);
                }
                Console.WriteLine();
            }
        }
    }
}
