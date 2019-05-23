using System.Collections;

namespace NUnit.Framework.Tests
{
    [TestFixture]
    public class AssertSyntaxTests
    {
        #region Simple Constraint Tests

        [Test]
        public void IsNull()
        {
            object nada = null;

            Assert.IsNull(nada);

            Assert.That(nada, Is.Null);
        }

        [Test]
        public void IsNotNull()
        {
            Assert.IsNotNull(42);

            Assert.That(42, Is.Not.Null);
        }

        [Test]
        public void IsTrue()
        {
            Assert.IsTrue(2 + 2 == 4);

            Assert.That(2 + 2 == 4, Is.True);
            Assert.That(2 + 2 == 4);
        }

        [Test]
        public void IsFalse()
        {
            Assert.IsFalse(2 + 2 == 5);

            Assert.That(2 + 2 == 5, Is.False);
        }

        [Test]
        public void IsNaN()
        {
            double d = double.NaN;
            float f = float.NaN;

            Assert.IsNaN(d);
            Assert.IsNaN(f);

            Assert.That(d, Is.NaN);
            Assert.That(f, Is.NaN);
        }

        [Test]
        public void EmptyStringTests()
        {
            Assert.IsEmpty("");
            Assert.IsNotEmpty("Hello!");

            Assert.That("", Is.Empty);
            Assert.That("Hello!", Is.Not.Empty);
        }

        [Test]
        public void EmptyCollectionTests()
        {
            Assert.IsEmpty(new bool[0]);
            Assert.IsNotEmpty(new int[] { 1, 2, 3 });

            Assert.That(new bool[0], Is.Empty);
            Assert.That(new int[] { 1, 2, 3 }, Is.Not.Empty);
        }

        #endregion Simple Constraint Tests

        #region TypeConstraint Tests

        [Test]
        public void ExactTypeTests()
        {
            Assert.AreEqual(typeof(string), "Hello".GetType());
            Assert.AreEqual("System.String", "Hello".GetType().FullName);
            Assert.AreNotEqual(typeof(int), "Hello".GetType());
            Assert.AreNotEqual("System.Int32", "Hello".GetType().FullName);

            Assert.That("Hello", Is.TypeOf(typeof(string)));
            Assert.That("Hello", Is.Not.TypeOf(typeof(int)));
        }

        [Test]
        public void InstanceOfTests()
        {
            Assert.IsInstanceOf(typeof(string), "Hello");
            Assert.IsNotInstanceOf(typeof(string), 5);

            Assert.That("Hello", Is.InstanceOf(typeof(string)));
            Assert.That(5, Is.Not.InstanceOf(typeof(string)));
        }

        [Test]
        public void AssignableFromTypeTests()
        {
            Assert.IsAssignableFrom(typeof(string), "Hello");
            Assert.IsNotAssignableFrom(typeof(string), 5);

            Assert.That("Hello", Is.AssignableFrom(typeof(string)));
            Assert.That(5, Is.Not.AssignableFrom(typeof(string)));
        }

        #endregion TypeConstraint Tests

        #region StringConstraint Tests

        [Test]
        public void SubstringTests()
        {
            string phrase = "Hello World!";
            string[] array = new string[] { "abc", "bad", "dba" };

            StringAssert.Contains("World", phrase);

            Assert.That(phrase, Does.Contain("World"));
            Assert.That(phrase, Does.Not.Contain("goodbye"));
            Assert.That(phrase, Does.Contain("WORLD").IgnoreCase);
            Assert.That(phrase, Does.Not.Contain("BYE").IgnoreCase);
            Assert.That(array, Is.All.Contains("b"));
        }

        [Test]
        public void StartsWithTests()
        {
            string phrase = "Hello World!";
            string[] greetings = new string[] { "Hello!", "Hi!", "Hola!" };

            StringAssert.StartsWith("Hello", phrase);

            Assert.That(phrase, Does.StartWith("Hello"));
            Assert.That(phrase, Does.Not.StartWith("Hi!"));
            Assert.That(phrase, Does.StartWith("HeLLo").IgnoreCase);
            Assert.That(phrase, Does.Not.StartWith("HI").IgnoreCase);
            Assert.That(greetings, Is.All.StartsWith("h").IgnoreCase);
        }

        [Test]
        public void EndsWithTests()
        {
            string phrase = "Hello World!";
            string[] greetings = new string[] { "Hello!", "Hi!", "Hola!" };

            StringAssert.EndsWith("!", phrase);

            Assert.That(phrase, Does.EndWith("!"));
            Assert.That(phrase, Does.Not.EndWith("?"));
            Assert.That(phrase, Does.EndWith("WORLD!").IgnoreCase);
            Assert.That(greetings, Is.All.EndsWith("!"));
        }

        [Test]
        public void EqualIgnoringCaseTests()
        {
            string phrase = "Hello World!";

            StringAssert.AreEqualIgnoringCase("hello world!", phrase);

            Assert.That(phrase, Is.EqualTo("hello world!").IgnoreCase);
            Assert.That(phrase, Is.Not.EqualTo("goodbye world!").IgnoreCase);
            Assert.That(new string[] { "Hello", "World" },
                Is.EqualTo(new object[] { "HELLO", "WORLD" }).IgnoreCase);
            Assert.That(new string[] { "HELLO", "Hello", "hello" },
                Is.All.EqualTo("hello").IgnoreCase);
        }

        [Test]
        public void RegularExpressionTests()
        {
            string phrase = "Now is the time for all good men to come to the aid of their country.";
            string[] quotes = new string[] { "Never say never", "It's never too late", "Nevermore!" };

            StringAssert.IsMatch("all good men", phrase);
            StringAssert.IsMatch("Now.*come", phrase);

            Assert.That(phrase, Does.Match("all good men"));
            Assert.That(phrase, Does.Match("Now.*come"));
            Assert.That(phrase, Does.Not.Match("all.*men.*good"));
            Assert.That(phrase, Does.Match("ALL").IgnoreCase);
            Assert.That(quotes, Is.All.Matches("never").IgnoreCase);
        }

        #endregion StringConstraint Tests

        #region Equality Tests

        [Test]
        public void EqualityTests()
        {
            int[] i3 = new int[] { 1, 2, 3 };
            double[] d3 = new double[] { 1.0, 2.0, 3.0 };
            int[] iunequal = new int[] { 1, 3, 2 };

            Assert.AreEqual(4, 2 + 2);
            Assert.AreEqual(i3, d3);
            Assert.AreNotEqual(5, 2 + 2);
            Assert.AreNotEqual(i3, iunequal);

            Assert.That(2 + 2, Is.EqualTo(4));
            Assert.That(2 + 2 == 4);
            Assert.That(i3, Is.EqualTo(d3));
            Assert.That(2 + 2, Is.Not.EqualTo(5));
            Assert.That(i3, Is.Not.EqualTo(iunequal));
        }

        [Test]
        public void EqualityTestsWithTolerance()
        {
            Assert.AreEqual(5.0d, 4.99d, 0.05d);
            Assert.AreEqual(5.0f, 4.99f, 0.05f);

            Assert.That(4.99d, Is.EqualTo(5.0d).Within(0.05d));
            Assert.That(4.0d, Is.Not.EqualTo(5.0d).Within(0.5d));
            Assert.That(4.99f, Is.EqualTo(5.0f).Within(0.05f));
            Assert.That(4.99m, Is.EqualTo(5.0m).Within(0.05m));
            Assert.That(3999999999u, Is.EqualTo(4000000000u).Within(5u));
            Assert.That(499, Is.EqualTo(500).Within(5));
            Assert.That(4999999999L, Is.EqualTo(5000000000L).Within(5L));
            Assert.That(5999999999ul, Is.EqualTo(6000000000ul).Within(5ul));
        }

        [Test]
        public void EqualityTestsWithTolerance_MixedFloatAndDouble()
        {
            Assert.That(2.20492d, Is.EqualTo(2.2d).Within(0.01f),
                "Double actual, Double expected, Single tolerance");
            Assert.That(2.20492d, Is.EqualTo(2.2f).Within(0.01d),
                "Double actual, Single expected, Double tolerance");
            Assert.That(2.20492d, Is.EqualTo(2.2f).Within(0.01f),
                "Double actual, Single expected, Single tolerance");
            Assert.That(2.20492f, Is.EqualTo(2.2f).Within(0.01d),
                "Single actual, Single expected, Double tolerance");
            Assert.That(2.20492f, Is.EqualTo(2.2d).Within(0.01d),
                "Single actual, Double expected, Double tolerance");
            Assert.That(2.20492f, Is.EqualTo(2.2d).Within(0.01f),
                "Single actual, Double expected, Single tolerance");
        }

        [Test]
        public void EqualityTestsWithTolerance_MixingTypesGenerally()
        {
            Assert.That(202d, Is.EqualTo(200d).Within(2),
                "Double actual, Double expected, int tolerance");
            Assert.That(4.87m, Is.EqualTo(5).Within(.25),
                "Decimal actual, int expected, Double tolerance");
            Assert.That(4.87m, Is.EqualTo(5ul).Within(1),
                "Decimal actual, ulong expected, int tolerance");
            Assert.That(487, Is.EqualTo(500).Within(25),
                "int actual, int expected, int tolerance");
            Assert.That(487u, Is.EqualTo(500).Within(25),
                "uint actual, int expected, int tolerance");
            Assert.That(487L, Is.EqualTo(500).Within(25),
                "long actual, int expected, int tolerance");
            Assert.That(487ul, Is.EqualTo(500).Within(25),
                "ulong actual, int expected, int tolerance");
        }

        #endregion Equality Tests

        #region Comparison Tests

        [Test]
        public void ComparisonTests()
        {
            Assert.Greater(7, 3);
            Assert.GreaterOrEqual(7, 3);
            Assert.GreaterOrEqual(7, 7);

            Assert.That(7, Is.GreaterThan(3));
            Assert.That(7, Is.GreaterThanOrEqualTo(3));
            Assert.That(7, Is.AtLeast(3));
            Assert.That(7, Is.GreaterThanOrEqualTo(7));
            Assert.That(7, Is.AtLeast(7));

            Assert.Less(3, 7);
            Assert.LessOrEqual(3, 7);
            Assert.LessOrEqual(3, 3);

            Assert.That(3, Is.LessThan(7));
            Assert.That(3, Is.LessThanOrEqualTo(7));
            Assert.That(3, Is.AtMost(7));
            Assert.That(3, Is.LessThanOrEqualTo(3));
            Assert.That(3, Is.AtMost(3));
        }

        #endregion Comparison Tests

        #region Collection Tests

        [Test]
        public void AllItemsTests()
        {
            object[] ints = new object[] { 1, 2, 3, 4 };
            object[] doubles = new object[] { 0.99, 2.1, 3.0, 4.05 };
            object[] strings = new object[] { "abc", "bad", "cab", "bad", "dad" };

            CollectionAssert.AllItemsAreNotNull(ints);
            CollectionAssert.AllItemsAreInstancesOfType(ints, typeof(int));
            CollectionAssert.AllItemsAreInstancesOfType(strings, typeof(string));
            CollectionAssert.AllItemsAreUnique(ints);

            Assert.That(ints, Is.All.Not.Null);
            Assert.That(ints, Has.None.Null);
            Assert.That(ints, Is.All.InstanceOf(typeof(int)));
            Assert.That(ints, Has.All.InstanceOf(typeof(int)));
            Assert.That(strings, Is.All.InstanceOf(typeof(string)));
            Assert.That(strings, Has.All.InstanceOf(typeof(string)));
            Assert.That(ints, Is.Unique);
            Assert.That(strings, Is.Not.Unique);
            Assert.That(ints, Is.All.GreaterThan(0));
            Assert.That(ints, Has.All.GreaterThan(0));
            Assert.That(ints, Has.None.LessThanOrEqualTo(0));
            Assert.That(strings, Is.All.Contains("a"));
            Assert.That(strings, Has.All.Contains("a"));
            Assert.That(strings, Has.Some.StartsWith("ba"));
            Assert.That(strings, Has.Some.Property("Length").EqualTo(3));
            Assert.That(strings, Has.Some.StartsWith("BA").IgnoreCase);
            Assert.That(doubles, Has.Some.EqualTo(1.0).Within(.05));
        }

        [Test]
        public void SomeItemTests()
        {
            object[] mixed = new object[] { 1, 2, "3", null, "four", 100 };
            object[] strings = new object[] { "abc", "bad", "cab", "bad", "dad" };

            Assert.That(mixed, Has.Some.Null);
            Assert.That(mixed, Has.Some.InstanceOf(typeof(int)));
            Assert.That(mixed, Has.Some.InstanceOf(typeof(string)));
            Assert.That(strings, Has.Some.StartsWith("ba"));
            Assert.That(strings, Has.Some.Not.StartsWith("ba"));
        }

        [Test]
        public void NoItemTests()
        {
            object[] ints = new object[] { 1, 2, 3, 4, 5 };
            object[] strings = new object[] { "abc", "bad", "cab", "bad", "dad" };

            Assert.That(ints, Has.None.Null);
            Assert.That(ints, Has.None.InstanceOf(typeof(string)));
            Assert.That(ints, Has.None.GreaterThan(99));
            Assert.That(strings, Has.None.StartsWith("qu"));
        }

        [Test]
        public void CollectionContainsTests()
        {
            int[] iarray = new int[] { 1, 2, 3 };
            string[] sarray = new string[] { "a", "b", "c" };

            Assert.Contains(3, iarray);
            Assert.Contains("b", sarray);
            CollectionAssert.Contains(iarray, 3);
            CollectionAssert.Contains(sarray, "b");
            CollectionAssert.DoesNotContain(sarray, "x");
            CollectionAssert.Contains(iarray, 1.0d);

            Assert.That(iarray, Has.Member(3));
            Assert.That(sarray, Has.Member("b"));
            Assert.That(sarray, Has.No.Member("x"));
            Assert.That(iarray, Has.Member(1.0d));

            Assert.That(iarray, Has.Some.EqualTo(3));
            Assert.That(iarray, Has.Member(3));
            Assert.That(sarray, Has.Some.EqualTo("b"));
            Assert.That(sarray, Has.None.EqualTo("x"));
            Assert.That(iarray, Has.None.SameAs(1.0d));
            Assert.That(iarray, Has.All.LessThan(10));
            Assert.That(sarray, Has.All.Length.EqualTo(1));
            Assert.That(sarray, Has.None.Property("Length").GreaterThan(3));
        }

        [Test]
        public void CollectionEquivalenceTests()
        {
            int[] ints1to5 = new int[] { 1, 2, 3, 4, 5 };
            int[] twothrees = new int[] { 1, 2, 3, 3, 4, 5 };
            int[] twofours = new int[] { 1, 2, 3, 4, 4, 5 };

            CollectionAssert.AreEquivalent(new int[] { 2, 1, 4, 3, 5 }, ints1to5);
            CollectionAssert.AreNotEquivalent(new int[] { 2, 2, 4, 3, 5 }, ints1to5);
            CollectionAssert.AreNotEquivalent(new int[] { 2, 4, 3, 5 }, ints1to5);
            CollectionAssert.AreNotEquivalent(new int[] { 2, 2, 1, 1, 4, 3, 5 }, ints1to5);
            CollectionAssert.AreNotEquivalent(twothrees, twofours);

            Assert.That(new int[] { 2, 1, 4, 3, 5 }, Is.EquivalentTo(ints1to5));
            Assert.That(new int[] { 2, 2, 4, 3, 5 }, Is.Not.EquivalentTo(ints1to5));
            Assert.That(new int[] { 2, 4, 3, 5 }, Is.Not.EquivalentTo(ints1to5));
            Assert.That(new int[] { 2, 2, 1, 1, 4, 3, 5 }, Is.Not.EquivalentTo(ints1to5));
        }

        [Test]
        public void SubsetTests()
        {
            int[] ints1to5 = new int[] { 1, 2, 3, 4, 5 };

            CollectionAssert.IsSubsetOf(new int[] { 1, 3, 5 }, ints1to5);
            CollectionAssert.IsSubsetOf(new int[] { 1, 2, 3, 4, 5 }, ints1to5);
            CollectionAssert.IsNotSubsetOf(new int[] { 2, 4, 6 }, ints1to5);
            CollectionAssert.IsNotSubsetOf(new int[] { 1, 2, 2, 2, 5 }, ints1to5);

            Assert.That(new int[] { 1, 3, 5 }, Is.SubsetOf(ints1to5));
            Assert.That(new int[] { 1, 2, 3, 4, 5 }, Is.SubsetOf(ints1to5));
            Assert.That(new int[] { 2, 4, 6 }, Is.Not.SubsetOf(ints1to5));
        }

        #endregion Collection Tests

        #region Property Tests

        [Test]
        public void PropertyTests()
        {
            string[] array = { "abc", "bca", "xyz", "qrs" };
            string[] array2 = { "a", "ab", "abc" };
            ArrayList list = new ArrayList(array);

            Assert.That(list, Has.Property("Count"));
            Assert.That(list, Has.No.Property("Length"));

            Assert.That("Hello", Has.Length.EqualTo(5));
            Assert.That("Hello", Has.Length.LessThan(10));
            Assert.That("Hello", Has.Property("Length").EqualTo(5));
            Assert.That("Hello", Has.Property("Length").GreaterThan(3));

            Assert.That(array, Has.Property("Length").EqualTo(4));
            Assert.That(array, Has.Length.EqualTo(4));
            Assert.That(array, Has.Property("Length").LessThan(10));

            Assert.That(array, Has.All.Property("Length").EqualTo(3));
            Assert.That(array, Has.All.Length.EqualTo(3));
            Assert.That(array, Is.All.Length.EqualTo(3));
            Assert.That(array, Has.All.Property("Length").EqualTo(3));
            Assert.That(array, Is.All.Property("Length").EqualTo(3));

            Assert.That(array2, Has.Some.Property("Length").EqualTo(2));
            Assert.That(array2, Has.Some.Length.EqualTo(2));
            Assert.That(array2, Has.Some.Property("Length").GreaterThan(2));

            Assert.That(array2, Is.Not.Property("Length").EqualTo(4));
            Assert.That(array2, Is.Not.Length.EqualTo(4));
            Assert.That(array2, Has.No.Property("Length").GreaterThan(3));

            Assert.That(List.Map(array2).Property("Length"), Is.EqualTo(new int[] { 1, 2, 3 }));
            Assert.That(List.Map(array2).Property("Length"), Is.EquivalentTo(new int[] { 3, 2, 1 }));
            Assert.That(List.Map(array2).Property("Length"), Is.SubsetOf(new int[] { 1, 2, 3, 4, 5 }));
            Assert.That(List.Map(array2).Property("Length"), Is.Unique);

            Assert.That(list, Has.Count.EqualTo(4));
        }

        #endregion Property Tests

        #region Not Tests

        [Test]
        public void NotTests()
        {
            Assert.That(42, Is.Not.Null);
            Assert.That(42, Is.Not.True);
            Assert.That(42, Is.Not.False);
            Assert.That(2.5, Is.Not.NaN);
            Assert.That(2 + 2, Is.Not.EqualTo(3));
            Assert.That(2 + 2, Is.Not.Not.EqualTo(4));
            Assert.That(2 + 2, Is.Not.Not.Not.EqualTo(5));
        }

        #endregion Not Tests

        #region Operator Tests

        [Test]
        public void NotOperator()
        {
            Assert.That(42, !Is.Null);
        }

        [Test]
        public void AndOperator()
        {
            Assert.That(7, Is.GreaterThan(5) & Is.LessThan(10));
        }

        [Test]
        public void OrOperator()
        {
            Assert.That(3, Is.LessThan(5) | Is.GreaterThan(10));
        }

        [Test]
        public void ComplexTests()
        {
            Assert.That(7, Is.Not.Null & Is.Not.LessThan(5) & Is.Not.GreaterThan(10));

            Assert.That(7, !Is.Null & !Is.LessThan(5) & !Is.GreaterThan(10));

#if false
            // TODO: Remove #if when mono compiler can handle null
#if MONO
            Constraint x = null;
            Assert.That(7, !x & !Is.LessThan(5) & !Is.GreaterThan(10));
            Expect(7, !x & !LessThan(5) & !GreaterThan(10));
#else
            Assert.That(7, !(Constraint)null & !Is.LessThan(5) & !Is.GreaterThan(10));
            Expect(7, !(Constraint)null & !LessThan(5) & !GreaterThan(10));
#endif
#endif
        }

        #endregion Operator Tests

        #region Invalid Code Tests

        #endregion Invalid Code Tests

        #region Assumptions

        [Test]
        public void PositiveAssumption()
        {
            Assume.That(true);

            Assert.Pass("This will be executed because of the assumption.");
        }

        [Test]
        public void NegativeAssumption()
        {
            Assume.That(false);

            Assert.Fail("This will not be executed because of the assumption.");
        }

        #endregion Assumptions

        #region Warnings

        [Test]
        public void PositiveWarning()
        {
            Warn.If(true, "This will emit a warning");
            Warn.Unless(false, "This will emit a warning");

            Assert.Pass("This test passes despite the warnings.");
        }

        [Test]
        public void NegativeWarning()
        {
            Warn.If(false, "This will not emit a warning");
            Warn.Unless(true, "This will not emit a warning");

            Assert.Pass("This test passes despite the warnings.");
        }

        #endregion Warnings
    }
}