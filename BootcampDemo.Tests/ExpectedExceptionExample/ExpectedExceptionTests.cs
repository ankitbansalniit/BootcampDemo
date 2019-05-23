using NUnit.Framework;
using System;

namespace ExpectedExceptionExample
{
    [TestFixture]
    public class ExpectedExceptionTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void HandlesArgumentExceptionAsType()
        {
            throw new ArgumentException();
        }
    }
}