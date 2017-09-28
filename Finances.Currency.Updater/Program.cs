// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Currency.Updater
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using Finances.Contract;
    using Finances.Contract.Banking;

    /// <summary>
    /// The program.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        private static void Main( string[] args )
        {
            Console.WriteLine( $"{DateTime.Now} Starting" );

            var xmlUrl = "https://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml?" + DateTime.Now;
            XNamespace ns = "http://www.ecb.int/vocabulary/2002-08-01/eurofxref";

            var currencies = new List<CurrencyIn>();

            try
            {
                var doc = XDocument.Load( xmlUrl );

                currencies = doc.Descendants( ns + "Cube" ).Where( c => c.Attribute( "currency" ) != null )
                    .Select( c => new CurrencyIn
                    {
                        Code = (string) c.Attribute( "currency" ),
                        ReasonToOneEuro = (decimal) c.Attribute( "rate" )
                    } ).Where( c => !string.IsNullOrEmpty( c.Code ) && c.ReasonToOneEuro != 0 )
                    .ToList();
            }
            catch ( Exception ex )
            {
                Console.WriteLine( ex.Message );
            }

            Console.WriteLine( $"{DateTime.Now} Got Currencies {currencies.Count} Sent to service" );
            var doneOk = SendCurrenciesToUpdate( currencies );
            Console.WriteLine( $"{DateTime.Now} response from service {( doneOk.Result.HasError ? doneOk.Result.ErrorMessage : doneOk.Result.Results.ToString() )} " );
            if ( doneOk.Result.HasError )
            {
                Console.ReadKey();
            }
        }

        /// <summary>
        /// The send currencies to update.
        /// </summary>
        /// <param name="currencies">
        /// The currencies.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        private static async Task<ActionResponse<int>> SendCurrenciesToUpdate( List<CurrencyIn> currencies )
        {
            var result = new ActionResponse<int>();

            using ( var client = new HttpClient() )
            {
                client.BaseAddress = new Uri( ConfigurationManager.AppSettings[ "Server" ] );
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue( "application/json" ) );

                var response = await client.PostAsJsonAsync( "Currency/Update", currencies );
                response.EnsureSuccessStatusCode();
                if ( !response.IsSuccessStatusCode )
                {
                    return result;
                }

                result = await response.Content.ReadAsAsync<ActionResponse<int>>();
                return result;
            }
        }
    }
}