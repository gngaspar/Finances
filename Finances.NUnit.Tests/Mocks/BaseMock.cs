// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseMock.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The base mock.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.NUnit.Tests.Mocks
{
    using System;

    using Moq;

    /// <summary>
    /// The base mock.
    /// </summary>
    /// <typeparam name="T">
    /// The type of Mock.
    /// </typeparam>
    public abstract class BaseMock<T> : BaseMock, IMock<T> where T : class
    {
        /// <summary>
        /// The mock.
        /// </summary>
        private object mock;

        /// <summary>
        /// The setup.
        /// </summary>
        /// <param name="mock">
        /// The mock.
        /// </param>
        public abstract void Setup( Mock<T> mock );

        /// <summary>
        /// The create.
        /// </summary>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public override object Create()
        {
            if ( this.mock == null )
            {
                var mockObject = new Mock<T>();
                this.Setup( mockObject );
                this.mock = mockObject;
            }

            return this.mock;
        }

        /// <summary>
        /// The get mock type.
        /// </summary>
        /// <returns>
        /// The <see cref="Type"/>.
        /// </returns>
        public override Type GetMockType()
        {
            return typeof( T );
        }
    }

    /// <summary>
    /// The base mock.
    /// </summary>
    public abstract class BaseMock
    {
        /// <summary>
        /// The get mock type.
        /// </summary>
        /// <returns>
        /// The <see cref="Type"/>.
        /// </returns>
        public abstract Type GetMockType();

        /// <summary>
        /// The create.
        /// </summary>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public abstract object Create();
    }
}