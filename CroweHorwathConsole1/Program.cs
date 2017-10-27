using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Configuration;
using Newtonsoft.Json;


namespace CroweHorwathConsole1
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient cons = new HttpClient();
            cons.BaseAddress = new Uri(ConfigurationManager.AppSettings["BaseAddress"]);
            cons.DefaultRequestHeaders.Accept.Clear();
            cons.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            MessageAPIGet(cons).Wait();
            Console.Read();

        }
        static async Task MessageAPIGet(HttpClient cons)
        {

            using (cons)
            {
                HttpResponseMessage res = await cons.GetAsync(ConfigurationManager.AppSettings["HelloStringURL"]);
                res.EnsureSuccessStatusCode();
                if (res.IsSuccessStatusCode)
                {
                    var responseMessage = await res.Content.ReadAsStringAsync();
                    var jsonResponse = JsonConvert.DeserializeObject<Message>(responseMessage);
                    Console.WriteLine(jsonResponse.TextToDisplay);
                }
            }       
        }
        private class Message
        {
            public int Id { get; set; }
            public string TextToDisplay { get; set; }
        }

    }
}
