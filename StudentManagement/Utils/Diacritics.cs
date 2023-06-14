using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Utils
{
    static class Diacritics
    {
        internal static List<string> RemoveDiacriticsForAList(List<string> textList)
        {
            for (int textListIndex = 0; textListIndex < textList.Count; textListIndex++)
            {
                textList[textListIndex] = RemoveDiacritics(textList[textListIndex]);
            }
            return textList;
        }
        internal static string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder(capacity: normalizedString.Length);

            for (int i = 0; i < normalizedString.Length; i++)
            {
                char c = normalizedString[i];
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder
                .ToString()
                .Normalize(NormalizationForm.FormC);
        }

        internal static bool CheckNoDiacriticsInText(string text)
        {
            return text == RemoveDiacritics(text);
        }
    }
}
