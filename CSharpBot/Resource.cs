using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace CSharpBot
{
    class Resource
    {
        public void Check()
        {
            WebClient client = new WebClient();
            
            if (Directory.Exists("img"))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                if (!File.Exists("img/img1.png"))
                {
                    client.DownloadFile("https://i.imgur.com/rtsO3KM_d.webp?maxwidth=760&fidelity=grand", "img/img1.png");
                    Console.WriteLine("img/img1.png, не был найден. Скачал.");
                }
                if (!File.Exists("img/img2.png"))
                {
                    client.DownloadFile("https://i.imgur.com/cN1hlHg_d.webp?maxwidth=760&fidelity=grand", "img/img2.png");
                    Console.WriteLine("img/img2.png, не был найден. Скачал.");
                }
                if (!File.Exists("img/otval.gif"))
                {
                    client.DownloadFile("https://i.imgur.com/Dv624zK.gif", "img/otval.gif");
                    Console.WriteLine("img/otval.gif, не был найден. Скачал.");
                }
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Не нашёл ничего. Скачиваю.");
                Console.ResetColor();

                Directory.CreateDirectory(@"img");
                client.DownloadFile("https://i.imgur.com/rtsO3KM_d.webp?maxwidth=760&fidelity=grand", @"img/img2.png");
                client.DownloadFile("https://i.imgur.com/cN1hlHg_d.webp?maxwidth=760&fidelity=grand", @"img/img2.png");
                client.DownloadFile("https://i.imgur.com/Dv624zK.gif", @"img/otval.gif");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Всё скачал.");
                Console.ResetColor();
            }
        }
    }
}
