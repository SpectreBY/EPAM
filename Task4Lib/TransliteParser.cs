using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4Lib
{
    /// <summary>
    /// A class that represents the translation of russian words into transliteration
    /// </summary>
    public class TransliteParser
    {
        /// <summary>
        /// A dictionary that stores latin letters received in Russian as a key
        /// </summary>
        private static Dictionary<char, string> dictionary = new Dictionary<char, string>
        {
            { 'а', "a" },
            { 'б', "b" },
            { 'в', "v" },
            { 'г', "g" },
            { 'д', "d" },
            { 'е', "ye" },
            { 'ё', "yo" },
            { 'ж', "zh" },
            { 'з', "z" },
            { 'и', "i" },
            { 'й', "j" },
            { 'к', "k" },
            { 'л', "l" },
            { 'м', "m" },
            { 'н', "n" },
            { 'о', "o" },
            { 'п', "p" },
            { 'р', "r" },
            { 'с', "s" },
            { 'т', "t" },
            { 'у', "u" },
            { 'ф', "f" },
            { 'х', "kh" },
            { 'ц', "ts" },
            { 'ч', "ch" },
            { 'ш', "sh" },
            { 'щ', "shch" },
            { 'ъ', "ie" },
            { 'ы', "y" },
            { 'ь', "'" },
            { 'э', "e" },
            { 'ю', "yu" },
            { 'я', "ya" }
        };

        /// <summary>
        /// Method for translating a russian word into transliteration
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string Parse(string message)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach(var item in message)
            {
                if (dictionary.ContainsKey(item))
                {
                    stringBuilder.Append(dictionary[item]);
                }
                else
                {
                    stringBuilder.Append(item);
                }
            }
            return stringBuilder.ToString();
        }
    }
}
