using System.Collections.Generic;
using System.Linq;

namespace nac.utilities;

public static class List
{

    public static List<BindableDynamicDictionary> CreateBindableDictionaryFromEnumerableT<T>(IEnumerable<T> list)
    {
        var listDict = CreateDictionaryFromEnumerable(list);
        var listBindDict = new List<BindableDynamicDictionary>();

        foreach (var dict in listDict)
        {
            var bindDict = new BindableDynamicDictionary(source: dict);
            listBindDict.Add(bindDict);
        }

        return listBindDict;
    }


    public static List<Dictionary<string, object>> CreateDictionaryFromEnumerable<T>(IEnumerable<T> list)
    {
        var listResult = new List<Dictionary<string, object>>();

        foreach (var item in list)
        {
            var itemProperties = from property in typeof(T).GetProperties()
                let value = property.GetValue(item, null)
                select new
                {
                    Name = property.Name,
                    Value = value
                };

            var dict = itemProperties.ToDictionary(e => e.Name, e => e.Value);
            listResult.Add(dict);
        }

        return listResult;
    }
    
    
    
}