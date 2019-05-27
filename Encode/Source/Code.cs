using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encode.Source
{

    internal class Code
    {
        #region Construktrs
        public Code()
        {
            //Добавляем в масив доступные символы
            chars.AddRange(letterEN);
            chars.AddRange(letterRU);
            chars.AddRange(marks);
            chars.AddRange(new char[] { '1', '2', '3', '4', '5', '6', '7', '9', '0', });

            Leaght = chars.Count;

            leaghtCharsArray = chars.Count;
        }
        public Code(string key, int LengthOneChar) : this()
        {
            if (key.Length / LengthOneChar != chars.Count)
                throw new DontCorrectedLargeExeption($" {key.Length} / {chars.Count * LengthOneChar} ");

            this.key = key;
            this.LengthOneChar = LengthOneChar;
            ChekWork();
        }
        #endregion


        protected string key { get; }

        /// <summary>
        /// Длинна закодироно символа.
        /// </summary>
        protected int LengthOneChar { get; }

        /// <summary>
        /// Исключение ключ по размеру несовпадает с нужным 
        /// </summary>
        public class NoFullLotExeption : Exception
        {
            public NoFullLotExeption(string message) : base(message) { }
        }


        #region Data
        private char[] letterEN { get; } = {'Q', 'q', 'W', 'w', 'E', 'e', 'R', 'r', 'T', 't', 'Y', 'y', 'U', 'u', 'I', 'i',
        'O','o','P','p','A','a','S','s', 'D','d','F','f','G','g','H','h','J','j','K','k','L','l','Z','z','X','x',
        'C','c','V','v','B','b','N','n','M','m'};

        private char[] letterRU { get; } = {'Й', 'й', 'ц', 'Ц', 'У', 'у', 'К', 'к', 'Е', 'е', 'Н', 'н', 'Г', 'ш', 'г', 'Ш', 'щ', 'Щ',
        'З', 'з','Х','х','ъ','Ъ','Ф','ф','Ы','ы','В','в','А','а','П','п','Р','р','О','о','Л','л','Д','д','Ж','ж','Э','э',
        'Я','я','Ч','ч','С','с','М','м','И','и','Т','т','Ь','ь','Б','б','Ю','ю'};

        private char[] marks { get; } = {'~','`', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '+', '+',
        '{','[',']','}','|',':',';','<',',','>','.','?','/',' '};

        public int leaghtCharsArray { get; }
        #endregion


        /// <summary>
        /// Коллекция со всеми символами.
        /// </summary>
        protected List<char> chars = new List<char>();

        public int Leaght { get; private set; }

        /// <summary>
        /// Проверка на исключение NoFullLotExeption.
        /// </summary>
        protected void ChekWork()
        {
            if (key.Length != LengthOneChar * chars.Count)
            {
                throw new NoFullLotExeption((LengthOneChar * chars.Count).ToString());
            }
        }

        /// <summary>
        /// Возвращает нужную длинну ключа.
        /// </summary>
        /// <returns>нужную длинну ключа</returns>
        protected int GetLeaght()
        {
            return LengthOneChar * chars.Count;
            //Convert.ToInt32(OneCharLargeNumeric.Value)
        }

        /// <summary>
        /// Делит строку на массив строк с размером LengthOneChar
        /// </summary>
        /// <param name="_key"></param>
        /// <returns></returns>
        protected string[] ConventToStringArray(string _key)
        {
            int index = 1;
            //делим ключ на масив символов
            char[] stringKey = _key.ToCharArray();
            string[] key = new string[stringKey.Length];
            for (int i = 0; i < key.Length; i += LengthOneChar)
            {
                for (int i2 = i; i2 < i + LengthOneChar; i2++)
                {
                    key[index] += stringKey[i2];
                }
                if (index < stringKey.Length) index++;
            }

            return key;
        }
    }

    public class DontCorrectedLargeExeption : Exception
    {
        public static string message;

        public DontCorrectedLargeExeption(string m) : base(message) { }
    }
}
