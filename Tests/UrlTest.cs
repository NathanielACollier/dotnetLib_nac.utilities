using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests;

[TestClass]
public class UrlTest
{
    
    [TestMethod]
    public void UrlQueryStringTests(){
        var url = new nac.utilities.Url("https://www.google.com");

        url.AddQuery("q", "(Apple Blossom) + (Oranges)");

        Assert.IsTrue(string.Equals(url.ToString(), "https://www.google.com/?q=(Apple+Blossom)+%2b+(Oranges)", StringComparison.OrdinalIgnoreCase));
    }


    [TestMethod]
    public void AddQueryParametersFromText()
    {
        var url = new nac.utilities.Url("https://www.google.com");

        url.AddQueryParametersFromText("where1=%22Attr_115749_2%22%3a%22Microsoft%22");
            
        Assert.IsTrue(string.Equals(url.ToString(), "https://www.google.com/?where1=%22Attr_115749_2%22%3a%22Microsoft%22",StringComparison.OrdinalIgnoreCase));
    }


    [TestMethod]
    public void AddQueryParametersFromTextWithDuplicateQueryParams()
    {
        var url = new nac.utilities.Url("https://www.google.com");
        url.AddQuery("q1", "Apple Sauce");
        url.AddQuery("q1", "Bacon");
            
        Assert.IsTrue(string.Equals(url.ToString(), "https://www.google.com/?q1=Apple+Sauce&q1=Bacon", StringComparison.OrdinalIgnoreCase));
    }



}