// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CurrencyServiceTests.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   Defines the CurrencyServiceTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.NUnit.Tests.Currency
{
    using System;
    using System.Threading.Tasks;

    using Finances.Contract.Banking;
    using Finances.Domain;

    using global::NUnit.Framework;

    /// <summary>
    /// The currency service tests.
    /// </summary>
    [TestFixture]
    public class CurrencyServiceTests : BaseTest
    {
        /// <summary>
        /// The service.
        /// </summary>
        private ICurrencyService service;

        /// <summary>
        /// The test initialize.
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            this.service = this.GetCurrencyService();
        }

        /// <summary>
        /// The test cleanup.
        /// </summary>
        [TearDown]
        public void TestCleanup()
        {
        }

        /// <summary>
        /// The convert should return converted value.
        /// </summary>
        /// <param name="from">
        /// The from.
        /// </param>
        /// <param name="to">
        /// The to.
        /// </param>
        /// <param name="amount">
        /// The amount.
        /// </param>
        /// <param name="expected">
        /// The expected.
        /// </param>
        [Test]
        [TestCase( "EUR", "PLN", 10, 42 )]
        [TestCase( "PLN", "USD", 10, 2.85714285714286 )]
        [TestCase( "PLN", "EUR", 8.4, 2 )]
        [TestCase( "TNG", "EUR", 10, 10 )]
        public void ConvertShouldReturnConvertedValue( string from, string to, decimal amount, decimal expected )
        {
            var input = new ConvertRequest { Amount = amount, FromCurrency = from, ToCurrency = to };

            var result = this.service.Convert( input );

            Assert.Multiple( () =>
                 {
                     Assert.NotNull( result );
                     Assert.NotNull( result.Result );
                     Assert.IsTrue( result.Status == TaskStatus.RanToCompletion );
                     Assert.AreEqual( Math.Round( expected, 6, MidpointRounding.ToEven ), Math.Round( result.Result, 6, MidpointRounding.ToEven ) );
                 } );
        }

        /// <summary>
        /// The convert should crash.
        /// </summary>
        /// <param name="from">
        /// The from.
        /// </param>
        /// <param name="to">
        /// The to.
        /// </param>
        /// <param name="amount">
        /// The amount.
        /// </param>
        [Test]
        [TestCase( "EUR", "EUR", 10 )]
        [TestCase( "EURO", "PLN", 10 )]
        [TestCase( "EUR", "PLNX", 10 )]
        [TestCase( "EUR", "PLN", 0 )]
        [TestCase( "", "PLN", 10 )]
        [TestCase( "EUR", "", 10 )]
        public void ConvertShouldCrash( string from, string to, decimal amount )
        {
            var input = new ConvertRequest { Amount = amount, FromCurrency = from, ToCurrency = to };
            var result = this.service.Convert( input );
            Assert.Multiple( () =>
                     {
                         Assert.IsTrue( result.Status == TaskStatus.Faulted );
                         Assert.IsTrue( result.Exception != null );
                     } );
        }

        /// <summary>
        /// The convert should crash null.
        /// </summary>
        [Test]
        public void ConvertShouldCrashNull()
        {
            var result = this.service.Convert( null );
            Assert.Multiple( () =>
                 {
                     Assert.IsTrue( result.Status == TaskStatus.Faulted );
                     Assert.IsTrue( result.Exception != null );
                 } );
        }
    }
}