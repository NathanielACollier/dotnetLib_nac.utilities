using System;
using System.Collections.Generic;

namespace nac.utilities;

public class Url
{
    private UriBuilder builder;

    public Url(string absoluteUrl)
    {
        var uri = new Uri(uriString: absoluteUrl, uriKind: UriKind.Absolute);
        this.builder = new UriBuilder(uri: uri);
    }

    public string Path {
        get {
            return this.builder.Path;
        } set {
            this.builder.Path = value;
        }
    }


    public Url Clone()
    {
        return new Url(absoluteUrl: this.ToString());
    }

    public override string ToString()
    {
        return builder.Uri.AbsoluteUri;
    }

    public Url AddQuery(string key, string value)
    {
        var query = System.Web.HttpUtility.ParseQueryString(builder.Query);

        query.Add(key, value);

        builder.Query = query.ToString();

        return this; // allow the chain to keep going
    }


    public Url ClearQuery()
    {
        builder.Query = string.Empty;

        return this; // allow chaining
    }


    public Url AddQueryParametersFromDictionary(Dictionary<string, string> parameters)
    {
        foreach (var kv in parameters)
        {
            this.AddQuery(key: kv.Key, value: kv.Value);
        }

        return this;
    }


    /*
     This function is public so we can pass in the result of a Building a search query for CCMS.  It will return a NameValueCollection
     */
    public Url AddQueryValueCollection(System.Collections.Specialized.NameValueCollection queryNVC)
    {
        var query = System.Web.HttpUtility.ParseQueryString(builder.Query);

        query.Add(queryNVC);

        builder.Query = query.ToString();

        return this; // allow the chain to keep going...
    }


    public Url AddQueryParametersFromText(string queryParametersText)
    {
        var query = System.Web.HttpUtility.ParseQueryString(queryParametersText);

        return this.AddQueryValueCollection(query);
    }
}