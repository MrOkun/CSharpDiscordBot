using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBot
{
    class Configurator
    {
        public void Start()
        {
            Console.WriteLine("Что вы хотите сделать? \n 1.Запустить бота. \n 2.Ввести токен.");

            var answer = Console.ReadLine();

            switch (answer)
            {
                case "1":
                    {
                        break;
                    }
                case "2":
                    {
                        TokenEdit();
                        break;
                    }
                default:
                    {
                        Console.Clear();
                        Console.WriteLine("Вы ввели не верное значение. Введите 1 или 2.");
                        Start();
                        break;
                    }
            }

        }

        private void TokenEdit()
        {
            Console.Write("Введите токен бота ---> ");

            if (!File.Exists(@"cfg/cfg.okun"))
            {
                Directory.CreateDirectory(@"cfg");
                File.Create(@"cfg/cfg.okun").Close();
            }

            var token = Console.ReadLine();

            using (StreamWriter sw = new(@"cfg/cfg.okun"))
            {
                sw.WriteLine(token);
            }

            Console.Clear();
        }

        public string TokenRead()
        {
            if (!File.Exists(@"cfg/cfg.okun"))
            {
                Console.WriteLine("Токен не введён!");
                TokenEdit();
            }

            using (StreamReader sr = new(@"cfg/cfg.okun"))
            {
                var token = sr.ReadToEnd();
                return token;
            }
        }
    }
}
