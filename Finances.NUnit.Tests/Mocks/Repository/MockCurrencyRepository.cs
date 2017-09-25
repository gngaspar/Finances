namespace Finances.NUnit.Tests.Mocks.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Finances.Contract.Banking;
    using Finances.Domain.Repository;

    using Moq;

    /// <summary>
    /// The mock currency repository.
    /// </summary>
    public class MockCurrencyRepository : BaseMock<ICurrencyRepository>
    {
        /// <summary>
        /// The setup.
        /// </summary>
        /// <param name="mock">
        /// The mock.
        /// </param>
        public override void Setup(Mock<ICurrencyRepository> mock)
        {

            var output = new CurrencyListResponse();
            var list = new List<CurrencyOut>();
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
            list.Add(euro);
            list.Add(pln);
            list.Add(dollar);
            list.Add(tango);
            output.Data = list;
            output.NumberOfItems = list.Count;
            
            mock.Setup(x => x.List()).Returns(Task.FromResult(output));
        }
    }
}