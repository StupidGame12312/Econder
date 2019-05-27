using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encode.Source
{
    internal class Decoder : Code
    {
        public Decoder(string key, int LengthOneChar) : base(key, LengthOneChar)
        { }

        /// <summary>
        /// Дешифрует сообщение
        /// </summary>
        /// <param name="messenge"></param>
        /// <returns></returns>
        public string GetDecryptedMessage(string messenge)
        {

            string[] DesKey = base.ConventToStringArray(base.key);
            string[] MessengeChars = ConventStringArrayMessenge(messenge);
            string result = null;

            //Console.WriteLine(DesKey.Length + "   " + MessengeChars.Length);



            try
            {
                for (int i = 0; i < MessengeChars.Length; i++)
                {
                    for (int y = 0; y < base.chars.Count; y++)
                    {
                        if (MessengeChars[i] == DesKey[y])
                        {
                            result += base.chars[y];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }


            return result;
        }

        /// <summary>
        /// Переводит соощение в масив строк
        /// </summary>
        /// <param name="messenge"></param>
        /// <returns></returns>
        private string[] ConventStringArrayMessenge(string messenge)
        {
            //Защита от ошибки с колличеством символов
            if (messenge.Length % base.LengthOneChar != 0) return null;


            int index = 0;
            char[] stringKey = messenge.ToCharArray();
            string[] _messenge = new string[stringKey.Length / LengthOneChar];
            for (int i = 0; i < messenge.Length; i += LengthOneChar)
            {
                for (int i2 = i; i2 < i + LengthOneChar; i2++)
                {
                    _messenge[index] += stringKey[i2];
                }
                if (index < stringKey.Length) index++;
            }

            return _messenge;
        }


    }
}
