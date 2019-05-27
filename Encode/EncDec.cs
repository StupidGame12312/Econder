using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encode
{
    public static class Encoder
    {
        /// <summary>
        /// Шифрует сообщение
        /// </summary>
        /// <param name="messenge">сам текст</param>
        /// <param name="key">сам ключ</param>
        /// <param name="LargeOneChar">Число равное колличеству симвалов в резултате шифрования одного из <code>messenge</code> </param>
        /// <returns>1</returns>
        public static string EncodeMessenge (string messenge , string key , int LargeOneChar)
        {
            Source.Encoder encoder = new Source.Encoder(key , LargeOneChar);
            var result = encoder.GetEncryptedMessage(messenge);
            return result;
        }
    }

    public static class Decoder
    {
        /// <summary>
        /// Декодирует сообщение
        /// </summary>
        /// <param name="messenge">сам текст</param>
        /// <param name="key">сам ключ</param>
        /// <param name="LargeOneChar">Число равное колличеству симвалов в резултате шифрования одного из <code>messenge</code> </param>
        /// <returns>1</returns>
        public static string DecodeMessenge(string messenge, string key, int LargeOneChar)
        {
            Source.Decoder encoder = new Source.Decoder(key, LargeOneChar);
            var result = encoder.GetDecryptedMessage(messenge);
            return result;
        }
    }
}
