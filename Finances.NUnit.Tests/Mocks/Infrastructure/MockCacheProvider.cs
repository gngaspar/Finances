using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.NUnit.Tests.Mocks.Infrastructure
{
    using Finances.Contract.Banking;
    using Finances.Domain;

    using Moq;

    public class MockCacheProvider : BaseMock<ICacheProvider>
    {
        /// <summary>
        /// The setup.
        /// </summary>
        /// <param name="mock">
        /// The mock.
        /// </param>
        public override void Setup( Mock<ICacheProvider> mock )
        {
            var currencyOuts = new List<CurrencyOut>();
            var euro = new CurrencyOut
            {
                ChangeAt = DateTime.MinValue,
                Code = "EUR",
                Name = "Euro",
                ReasonToOneEuro = 0
            };
            var pln = new CurrencyOut
            {
                ChangeAt = DateTime.MinValue,
                Code = "PLN",
                Name = "Zlote",
                ReasonToOneEuro = 4.2m
            };
            var dollar = new CurrencyOut
            {
                ChangeAt = DateTime.MinValue,
                Code = "USD",
                Name = "Dollar",
                ReasonToOneEuro = 1.2m
            };
            var tango = new CurrencyOut
            {
                ChangeAt = DateTime.MinValue,
                Code = "TNG",
                Name = "Same like Euro",
                ReasonToOneEuro = 0
            };
            currencyOuts.Add( euro );
            currencyOuts.Add( pln );
            currencyOuts.Add( dollar );
            currencyOuts.Add( tango );


            mock.Setup( i => i.Currencies ).Returns( currencyOuts );

            //mock.Setup( i => i.Banks ).Returns( currencyOuts );
        }
    }
}
