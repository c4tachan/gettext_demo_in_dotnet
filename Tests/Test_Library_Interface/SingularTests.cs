using NUnit.Framework;

using static gettext_in_blazor.Shared.CustomExtensions.Gettext;

namespace Test_Gettext
{
    public class SingularTests
    {
        [SetUp]
        public void Setup()
        {
            SetLocale("en_US");
        }

        [Test]
        public void TestSingular()
        {
            Assert.AreEqual("Generic Singular in en_US", _("Generic Singular in en_US"));
        }

        [Test]
        public void TestFormattedSingularUsingString()
        {
            var testVal = "inserted by formatter!";
            Assert.AreEqual($"Generic formatted singular with added {testVal.GetType()} {testVal}", _f("Generic formatted singular with added System.String {0}", testVal));
            Assert.AreEqual($"Generic formatted singular with added {testVal.GetType()} {testVal}", _f("Generic formatted singular with added {0} {1}", testVal.GetType(), testVal));
        }

        [Test]
        public void TestFormattedSingularUsingInt()
        {
            var testVal = 42;
            Assert.AreEqual($"Generic formatted singular with added {testVal.GetType()} {testVal}", _f("Generic formatted singular with added {0} {1}", testVal.GetType(), testVal));
        }

        [Test]
        public void TestFormattedSingularUsingDouble()
        {
            double testVal = 42.0;
            Assert.AreEqual($"Generic formatted singular with added {testVal.GetType()} {testVal}", _f("Generic formatted singular with added {0} {1}", testVal.GetType(), testVal));
        }
    }
}