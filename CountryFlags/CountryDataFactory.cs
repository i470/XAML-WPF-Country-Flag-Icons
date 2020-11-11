using EnumsNET;
using System;
using System.Collections.Generic;

namespace CountryFlags
{
    public static class CountryDataFactory
    {
        public static Lazy<IDictionary<Enum, string>> CountryIndex { get; }

        static CountryDataFactory()
        {
            if (CountryIndex == null)
            {
                CountryIndex = new Lazy<IDictionary<Enum, string>>(Create);
            }
        }


        internal static IDictionary<Enum, string> Create()
        {
            var dictionary = new Dictionary<Enum, string>();

            foreach (var country in Enum.GetValues(typeof(CountryEnum)))
            {
                dictionary.Add((CountryEnum)country, ((CountryEnum)country).AsString(EnumFormat.Description));
            }

            return dictionary;
        }

    }
}
