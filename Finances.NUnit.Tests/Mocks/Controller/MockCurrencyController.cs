using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.NUnit.Tests.Mocks.Controller
{
    using Finances.Contract.Banking;

    using global::NUnit.Framework;

    using Moq;

    public class MockCurrencyController :BaseMock<ICurrencyController>
    {
        public override void Setup(Mock<ICurrencyController> mock)
        {
            // mock.Setup(x => x.Convert(Is.InstanceOf<>())
        }
    }
}
