using Microsoft.VisualStudio.TestTools.UnitTesting;
using nac.utilities;

namespace Tests;

[TestClass]
public class OptionalTest
{
    [TestMethod]
    public void IntegerTesting()
    {
        Optional<int> myNumber = 33;

        Assert.IsTrue(myNumber == 33);
        Assert.IsTrue(myNumber != 31);

        Assert.IsTrue(myNumber.IsSet);
    }
}