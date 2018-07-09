using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task2
{
    public static class MyConverter
    {
        /// <summary>
        /// Метод преобразования строки в целое число.
        /// </summary>
        /// <param name="source">Type: System.String. Строка.</param>
        /// <returns>Type: System.Int32. Число, полученное из строки.</returns>
        /// <exception cref="ArgumentNullException"
        /// <exception cref="OverflowException"
        /// <exception cref="UtoiConvertException"
        public static int Utoi(string source)
        {
            if(string.IsNullOrEmpty(source))
            {
                throw new ArgumentNullException();
            }

            bool isSigned = false;
            int result = 0;
            if (source.StartsWith("-"))
            {
                isSigned = true;
            }

            try
            {
                if (isSigned)
                {
                    result = UtfToPositiveInt(source.Substring(1));
                    result = -result;
                }
                else
                {
                    result = UtfToPositiveInt(source);                    
                }
            }
            catch (OverflowException)
            {
                throw;
            }
            catch (FormatException e)
            {
                UtoiConvertException invalidChar = new UtoiConvertException("An error has occurred while converting the string to integer", e);
                foreach (DictionaryEntry item in e.Data)
                {
                    if ((string)item.Key == "TokenIndex")
                    {
                        invalidChar.TokenIndex = isSigned ? (int)item.Value + 1 : (int)item.Value;
                    }
                }
                throw invalidChar;
            }

            return result;

        }
        /// <summary>
        /// Вспомогательный метод, преобразующий строку в положительное число.
        /// </summary>
        /// <param name="source">Type: System.String. Строка, содержащая только цифры.</param>
        /// <returns>Type: System.Int32. Число, полученное из строки.</returns>
        /// <exception cref="ArgumentNullException"
        /// <exception cref="OverflowException"
        /// <exception cref="FormatException"
        private static int UtfToPositiveInt(string source)
        {
            if(string.IsNullOrEmpty(source))
            {
                throw new ArgumentNullException();
            }
            int result = 0;
            int index = 0;
            while (index < source.Length)
            {
                char currentToken = source[index];
                if (currentToken >= '0' && currentToken <= '9')
                {
                    checked
                    {
                        result *= 10;
                        result += currentToken - '0';
                    }
                }
                else
                {
                    FormatException format = new FormatException("Error: Only digits are valid.");
                    format.Data.Add("TokenIndex", index);
                    throw format;
                }
                index++;
            }
            

            return result;
        }
    }
}
