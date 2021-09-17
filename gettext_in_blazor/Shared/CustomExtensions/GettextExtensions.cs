using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NGettext;
using NGettext.Loaders;

namespace gettext_in_blazor.Shared.CustomExtensions
{
    // Adds string extension methods to make the usage of gettext awesome in this project.
    public static class Gettext
    {
        private static string locale;

        private static string localizationPath;

        private static ICatalog catalog;

        private static ICatalog Catalog
        {
            get
            {
                if(catalog == default)
                {
                    SetLocale("en_us");
                    // Should probably throw some kind of error here too!
                }
                return catalog;
            }
        }

        // Expects the locale provided to be in the en_US format
        public static void SetLocale(string newLocale)
        {
            locale = newLocale;
            catalog = new Catalog(new MoAstPluralLoader($"{localizationPath}/{locale}.mo"));
        }

        // Singular form of a string
        public static string _(string key) => catalog.GetString(key);

        // Singular form of a formatted string
        public static string _f(string key, params object[] args) => catalog.GetString(key, args);

        // Contextual Singular form of a string
        public static string _c(string context, string key) => catalog.GetParticularString(context, key);

        // Contextual Singular form of a formatted string
        public static string _cf(string context, string key, params object[] args) => catalog.GetParticularString(context, key, args);

        // Plural form of a string
        public static string _(string key, string plural, long n) => catalog.GetPluralString(key, plural, n);

        // Plural form of a formatted string
        public static string _f(string key, string plural, long n, params object[] args) => catalog.GetPluralString(key, plural, n, args);

        // Contextual Plural form of a string
        public static string _c(string context, string key, string plural, long n) => catalog.GetParticularPluralString(context, key, plural, n);

        // Contextual Plural form of a formatted string
        public static string _cf(string context, string key, string plural, long n, params object[] args) => catalog.GetParticularPluralString(context, key, plural, n, args);
    }
}
