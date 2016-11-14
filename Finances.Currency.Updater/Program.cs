namespace Finances.Currency.Updater
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using Finances.Contract;
    using Finances.Contract.Banking;

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine($"{DateTime.Now} Starting");

            var xmlUrl = "https://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml?" + DateTime.Now;
            XNamespace ns = "http://www.ecb.int/vocabulary/2002-08-01/eurofxref";

            var currencies = new List<CurrencyIn>();

            try
            {
                var doc = XDocument.Load(xmlUrl);

                currencies = doc.Descendants(ns + "Cube").Where(c => c.Attribute("currency") != null)
                    .Select(c => new CurrencyIn
                    {
                        Code = (string)c.Attribute("currency"),
                        ReasonToOneEuro = (decimal)c.Attribute("rate")
                    }).Where(c => !string.IsNullOrEmpty(c.Code) && c.ReasonToOneEuro != 0)
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine($"{DateTime.Now} Got Currencies {currencies.Count}");

            Console.WriteLine($"{DateTime.Now} Sent to service");
            var doneOk = SendCurrenciesToUpdate(currencies);
            Console.ReadKey();
            Console.WriteLine($"{DateTime.Now} response from service {doneOk}");
        }

        private static async Task<ActionResponse> SendCurrenciesToUpdate(List<CurrencyIn> currencies)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:3001/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.PostAsJsonAsync("Currency/Update", currencies);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"{DateTime.Now} IsSuccessStatusCode");
                    var result = await response.Content.ReadAsAsync<ActionResponse>();

                    Console.WriteLine($"{DateTime.Now} {result.Results}");
                }

                return new ActionResponse();
            }
        }
    }
}