using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GetAndPostSoap
{
    class Program
    {
        static void Main(string[] args)
        {

            // GetRequest("https://www.facebook.com");
            PostRequest("https://posttestserver.com/post.php");
            Console.ReadKey();
        }

        async static void GetRequest(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                using(HttpResponseMessage response = await client.GetAsync(url))
                {
                    using(HttpContent content = response.Content)
                    {
                        // string mycontent = await content.ReadAsStringAsync();
                        HttpContentHeaders headers = content.Headers;
                        Console.WriteLine(headers);
                    }                    
                    
                }                
                
            }

        }
        async static void PostRequest(string url)
        {
            IEnumerable<KeyValuePair<string, string>> queries = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("query1", "chung"),
                new KeyValuePair<string, string>("query2", "nguyen")
            };

            HttpContent q = new FormUrlEncodedContent(queries);
            using (HttpClient client = new HttpClient())
            {
                using(HttpResponseMessage response = await client.PostAsync(url,q))
                {
                    using(HttpContent content = response.Content)
                    {
                        string mycontent = await content.ReadAsStringAsync();
                        HttpContentHeaders headers = content.Headers;
                        Console.WriteLine(mycontent);
                    }
                }
            }
        }
    }
}
