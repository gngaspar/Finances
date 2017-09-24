using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.NUnit.Tests
{
    using Finances.Domain.Repository;

    using Moq;

    public class BaseTest
    {
        private MockRepository mockRepository;

        private Mock<ICurrencyRepository> mockCurrencyRepository;
    }
}
