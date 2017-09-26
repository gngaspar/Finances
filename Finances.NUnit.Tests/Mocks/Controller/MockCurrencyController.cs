// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MockCurrencyController.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   Defines the MockCurrencyController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.NUnit.Tests.Mocks.Controller
{
    using Finances.Contract.Banking;
    using Moq;

    /// <summary>
    /// The mock currency controller.
    /// </summary>
    public class MockCurrencyController : BaseMock<ICurrencyController>
    {
        /// <summary>
        /// The setup.
        /// </summary>
        /// <param name="mock">
        /// The mock.
        /// </param>
        public override void Setup( Mock<ICurrencyController> mock )
        {
            // mock.Setup(x => x.Convert(Is.InstanceOf<>())
        }
    }
}
