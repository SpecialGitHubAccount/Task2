using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    static class StringExtension
    {
        /// <summary>
        /// Метод расширения, возвращающий первый символ строки.
        /// </summary>
        /// <param name="source">Type: System.String. Строка, из которой будет получен первый символ.</param>
        /// <returns>Type: System.Char. Первый символ строки</returns>
        /// <exception cref="ArgumentNullException"
        public static char GetFirstChar(this string source)
        {
            if(string.IsNullOrEmpty(source))
            {
                throw new ArgumentNullException();
            }
            return source[0];
        }
    }
}
