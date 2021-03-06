namespace NUnit.Samples.Money
{
    using NUnit.Framework;

    [TestFixture]
    public class MoneyTest
    {
        private Money f12CHF;
        private Money f14CHF;
        private Money f7USD;
        private Money f21USD;

        private MoneyBag fMB1;
        private MoneyBag fMB2;

        [SetUp]
        protected void SetUp()
        {
            f12CHF = new Money(12, "CHF");
            f14CHF = new Money(14, "CHF");
            f7USD = new Money(7, "USD");
            f21USD = new Money(21, "USD");

            fMB1 = new MoneyBag(f12CHF, f7USD);
            fMB2 = new MoneyBag(f14CHF, f21USD);
        }

        [Test]
        public void BagMultiply()
        {
            Money[] bag = { new Money(24, "CHF"), new Money(14, "USD") };
            MoneyBag expected = new MoneyBag(bag);
            Assert.AreEqual(expected, fMB1.Multiply(2));
            Assert.AreEqual(fMB1, fMB1.Multiply(1));
            Assert.IsTrue(fMB1.Multiply(0).IsZero);
        }

        [Test]
        public void BagNegate()
        {
            Money[] bag = { new Money(-12, "CHF"), new Money(-7, "USD") };
            MoneyBag expected = new MoneyBag(bag);
            Assert.AreEqual(expected, fMB1.Negate());
        }

        [Test]
        public void BagSimpleAdd()
        {
            Money[] bag = { new Money(26, "CHF"), new Money(7, "USD") };
            MoneyBag expected = new MoneyBag(bag);
            Assert.AreEqual(expected, fMB1.Add(f14CHF));
        }

        [Test]
        public void BagSubtract()
        {
            Money[] bag = { new Money(-2, "CHF"), new Money(-14, "USD") };
            MoneyBag expected = new MoneyBag(bag);
            Assert.AreEqual(expected, fMB1.Subtract(fMB2));
        }

        [Test]
        public void BagSumAdd()
        {
            Money[] bag = { new Money(26, "CHF"), new Money(28, "USD") };
            MoneyBag expected = new MoneyBag(bag);
            Assert.AreEqual(expected, fMB1.Add(fMB2));
        }

        [Test]
        public void IsZero()
        {
            Assert.IsTrue(fMB1.Subtract(fMB1).IsZero);

            Money[] bag = { new Money(0, "CHF"), new Money(0, "USD") };
            Assert.IsTrue(new MoneyBag(bag).IsZero);
        }

        [Test]
        public void MixedSimpleAdd()
        {
            Money[] bag = { f12CHF, f7USD };
            MoneyBag expected = new MoneyBag(bag);
            Assert.AreEqual(expected, f12CHF.Add(f7USD));
        }

        [Test]
        public void MoneyBagEquals()
        {
            Assert.IsFalse(fMB1.Equals(null));

            Assert.IsTrue(fMB1.Equals(fMB1));
            MoneyBag equal = new MoneyBag(new Money(12, "CHF"), new Money(7, "USD"));
            Assert.IsTrue(fMB1.Equals(equal));
            Assert.IsTrue(!fMB1.Equals(f12CHF));
            Assert.IsTrue(!f12CHF.Equals(fMB1));
            Assert.IsTrue(!fMB1.Equals(fMB2));
        }

        [Test]
        public void MoneyBagHash()
        {
            MoneyBag equal = new MoneyBag(new Money(12, "CHF"), new Money(7, "USD"));
            Assert.AreEqual(fMB1.GetHashCode(), equal.GetHashCode());
        }

        [Test]
        public void MoneyEquals()
        {
            Assert.IsFalse(f12CHF.Equals(null));
            Money equalMoney = new Money(12, "CHF");
            Assert.IsTrue(f12CHF.Equals(f12CHF));
            Assert.IsTrue(f12CHF.Equals(equalMoney));
            Assert.IsFalse(f12CHF.Equals(f14CHF));
        }

        [Test]
        public void MoneyHash()
        {
            Assert.IsFalse(f12CHF.Equals(null));
            Money equal = new Money(12, "CHF");
            Assert.AreEqual(f12CHF.GetHashCode(), equal.GetHashCode());
        }

        [Test]
        public void Normalize()
        {
            Money[] bag = { new Money(26, "CHF"), new Money(28, "CHF"), new Money(6, "CHF") };
            MoneyBag moneyBag = new MoneyBag(bag);
            Money[] expected = { new Money(60, "CHF") };
            MoneyBag expectedBag = new MoneyBag(expected);
            Assert.AreEqual(expectedBag, moneyBag);
        }

        [Test]
        public void Normalize2()
        {
            Money expected = new Money(7, "USD");
            Assert.AreEqual(expected, fMB1.Subtract(f12CHF));
        }

        [Test]
        public void Normalize3()
        {
            Money[] s1 = { new Money(12, "CHF"), new Money(3, "USD") };
            MoneyBag ms1 = new MoneyBag(s1);
            Money expected = new Money(4, "USD");
            Assert.AreEqual(expected, fMB1.Subtract(ms1));
        }

        [Test]
        public void Normalize4()
        {
            Money[] s1 = { new Money(12, "CHF"), new Money(3, "USD") };
            MoneyBag ms1 = new MoneyBag(s1);
            Money expected = new Money(-3, "USD");
            Assert.AreEqual(expected, f12CHF.Subtract(ms1));
        }

        [Test]
        public void Print()
        {
            Assert.AreEqual("[12 CHF]", f12CHF.ToString());
        }

        [Test]
        public void SimpleAdd()
        {
            Money expected = new Money(26, "CHF");
            Assert.AreEqual(expected, f12CHF.Add(f14CHF));
        }

        [Test]
        public void SimpleBagAdd()
        {
            Money[] bag = { new Money(26, "CHF"), new Money(7, "USD") };
            MoneyBag expected = new MoneyBag(bag);
            Assert.AreEqual(expected, f14CHF.Add(fMB1));
        }

        [Test]
        public void SimpleMultiply()
        {
            Money expected = new Money(28, "CHF");
            Assert.AreEqual(expected, f14CHF.Multiply(2));
        }

        [Test]
        public void SimpleNegate()
        {
            Money expected = new Money(-14, "CHF");
            Assert.AreEqual(expected, f14CHF.Negate());
        }

        [Test]
        public void SimpleSubtract()
        {
            Money expected = new Money(2, "CHF");
            Assert.AreEqual(expected, f14CHF.Subtract(f12CHF));
        }
    }
}