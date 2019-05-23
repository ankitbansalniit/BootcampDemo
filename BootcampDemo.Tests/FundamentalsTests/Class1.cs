using BootcampDemo.Examples;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace FundamentalsTests
{
    public class Class1
    {
        public void GetOutput_InputDividableBy3And5_ReturnFizzBuzz()
        {
            var result = FizzBuzz.GetOutput(15);

            Assert.That(result, Is.EqualTo("FizzBuzz"));
        }

        [Test]
        public void GetOutput_InputDividableBy3Only_ReturnFizz()
        {
        }
    }
}