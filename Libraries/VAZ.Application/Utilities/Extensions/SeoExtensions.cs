using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAZ.Application.Utilities.Extensions
{
    public static class SeoExtensions
    {
        #region Fields

        private static Dictionary<string, string> _seoCharacterTable;
        private static readonly object s_lock = new object();

        #endregion

        #region Product tag

        public static string GetSeName(string name, bool convertNonWesternChars, bool allowUnicodeCharsInUrls, string charConversions = null)
        {
            return GenerateSlug(name, convertNonWesternChars, allowUnicodeCharsInUrls, false, charConversions);
        }
        public static string GenerateSlug(string name, bool convertNonWesternChars, bool allowUnicodeCharsInUrls, bool allowslashChar, string charConversions = null)
        {
            if (string.IsNullOrEmpty(name))
                return name;

            var okChars = "abcdefghijklmnopqrstuvwxyz1234567890 _-";
            if (allowslashChar)
                okChars += '/';

            name = name.Trim().ToLowerInvariant();

            if (convertNonWesternChars)
            {
                if (!string.IsNullOrEmpty(charConversions) && _seoCharacterTable == null)
                    InitializeSeoCharacterTable(charConversions);
            }

            var sb = new StringBuilder();
            foreach (var c in name.ToCharArray())
            {
                var c2 = c.ToString();
                if (convertNonWesternChars && _seoCharacterTable != null)
                {
                    if (_seoCharacterTable.ContainsKey(c2))
                        c2 = _seoCharacterTable[c2];
                }

                if (allowUnicodeCharsInUrls)
                {
                    if (char.IsLetterOrDigit(c) || okChars.Contains(c2))
                        sb.Append(c2);
                }
                else if (okChars.Contains(c2))
                {
                    sb.Append(c2);
                }
            }
            var name2 = sb.ToString();
            name2 = name2.Replace(" ", "-");
            while (name2.Contains("--"))
                name2 = name2.Replace("--", "-");
            while (name2.Contains("__"))
                name2 = name2.Replace("__", "_");
            return name2;
        }

        private static void InitializeSeoCharacterTable(string charConversions)
        {
            lock (s_lock)
            {
                if (_seoCharacterTable == null)
                {
                    _seoCharacterTable = new Dictionary<string, string>();

                    foreach (var conversion in charConversions.Split(";"))
                    {
                        var strLeft = conversion.Split(":").FirstOrDefault();
                        var strRight = conversion.Split(":").LastOrDefault();
                        if (!string.IsNullOrEmpty(strLeft) && !_seoCharacterTable.ContainsKey(strLeft))
                        {
                            _seoCharacterTable.Add(strLeft.Trim(), strRight.Trim());
                        }
                    }
                }
            }

        }

        #endregion
    }
}
