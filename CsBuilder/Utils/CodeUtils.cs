using System.Collections.Generic;

namespace CsBuilder.Utils
{
    public static class CodeUtils
    {
        public static string Placeholders(int numberOfPlaceholders, string joinedBy = ", ")
        {
            var placeholders = new List<string>();
            for (int i = 0; i < numberOfPlaceholders; i++)
            {
                placeholders.Add(string.Format("{{{0}}}", i));
            }

            return string.Join(joinedBy, placeholders.ToArray());
        }
    }
}