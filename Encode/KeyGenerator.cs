using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encode
{
    class KeyGenerator
    {
        #region Data chars 

        private static char[] num { get; } = { '9', '8', '7', '6', '5', '4', '3', '2', '1', '0', };
        private static char[] letter { get; } = {'Q', 'q', 'W', 'w', 'E', 'e', 'R', 'r', 'T', 't', 'Y', 'y', 'U', 'u', 'I', 'i',
        'O','o','P','p','A','a','S','s', 'D','d','F','f','G','g','H','h','J','j','K','k','L','l','Z','z','X','x',
        'C','c','V','v','B','b','N','n','M','m'};
        private static char[] marks { get; } = {'~','`', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '+', '+',
        '{','[',']','}','|',':',';','<',',','>','.','?','/',};

        #endregion

        /// <summary>
        /// Режимы генерации ключа.
        /// </summary>
        public enum Mods {OnlyNum, OnlyLetters, LettersNum, LettersMarks, LetterNumMarks }

        //public async void ChangePass(int _long, Mods mod  , TextBox box)
        //{
        //    string key = await Task.Run(() => CreatPass(_long, mod));
        //    box.Text = key;

        //}

        /// <summary>
        /// Создаёт ключ длинной _long
        /// </summary>
        /// <param name="_long"></param>
        /// <param name="mod"></param>
        /// <returns></returns>
        public static string CreatPass(int _long, Mods mod)
        {
            Random rnd = new Random();
            string key = "";
            List<char> chars = new List<char>();

            switch (mod)
            {
                case Mods.OnlyNum:
                    chars.AddRange(num);

                    break;
                case Mods.OnlyLetters:
                    chars.AddRange(letter);

                    break;
                case Mods.LettersNum:
                    chars.AddRange(letter);
                    chars.AddRange(num);

                    break;
                case Mods.LettersMarks:
                    chars.AddRange(letter);
                    chars.AddRange(marks);

                    break;
                case Mods.LetterNumMarks:
                    chars.AddRange(letter);
                    chars.AddRange(num);
                    chars.AddRange(marks);

                    break;

            }


            for (int i = 0; i < _long; i++)
            {
                key += chars[rnd.Next(chars.Count)];
            }

            return key;
        }
    }
}
