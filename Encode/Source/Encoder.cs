using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encode.Source
{

    internal class Encoder : Code
    {
        //Constructr
        public Encoder(string key, int LengthOneChar) : base(key, LengthOneChar) { }

        /// <summary>
        /// Возвращает длинну ключа с учетом длинны зашифровоного символа.
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static int GetLeaght(int num)
        {
            return num * new Code().Leaght;
        }

        /// <summary>
        /// Шифрует сообщение.
        /// </summary>
        /// <param name="messenge"></param>
        /// <returns></returns>
        public string GetEncryptedMessage(string messenge)
        {
            //берём ключ 
            string[] codek = base.ConventToStringArray(base.key);
            // шифруем
            char[] words = messenge.ToCharArray();
            string result = "";
            foreach (char chars in words)
            {
                for (int i2 = 0; i2 < base.chars.Count; i2++)
                {
                    if (chars == base.chars[i2])
                    {
                        result += codek[i2];
                    }
                }
            }
            return result;
        }
    }

    
    
}
