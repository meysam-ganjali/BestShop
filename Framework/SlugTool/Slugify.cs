using System.Globalization;
using System.Text.RegularExpressions;
using System.Text;

namespace Framework.SlugTool;
public static class Slugify {
    public static string ToSlug(this string phrase) {
        var s = phrase.RemoveDiacritics().ToLower();
        //Remove invalid Characters
        s = Regex.Replace(s, @"[^\u0600-\u06FF\uFB8A\u067E\u0686\u06AF\u200C\u200Fa-z0-9\s-]", "");
        //Single Space
        s = Regex.Replace(s, @"\s+", " ").Trim();
        //Cut And Trim
        s = s.Substring(0, s.Length <= 100 ? s.Length : 45).Trim();
        //Insert hyphens
        s = Regex.Replace(s, @"\s", "_");
        //half space
        s = Regex.Replace(s, @"", "_");
        return s.ToLower();
    }

    public static string RemoveDiacritics(this string text) {
        if (string.IsNullOrWhiteSpace(text)) return string.Empty;
        var normalizedString = text.Normalize(NormalizationForm.FormKC);
        var stringBulder = new StringBuilder();
        foreach (var c in normalizedString) {
            var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
            if (unicodeCategory != UnicodeCategory.NonSpacingMark) stringBulder.Append(c);
        }

        return stringBulder.ToString().Normalize(NormalizationForm.FormC);
    }
}