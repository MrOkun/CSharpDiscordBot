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
        public struct ResourceFile
        {
            public ResourceFile(string path, string url)
            {
                this.Url = url;
                this.Path = path;
            }

            public string Path;
            public string Url;
        }

        private ResourceFile[] _resources;

        public void Check()
        {
            WebClient client = new WebClient();

            _resources = new ResourceFile[4];

            _resources[0] = new ResourceFile("img/img1.png", "https://i.imgur.com/rtsO3KM_d.webp?maxwidth=760&fidelity=grand");
            _resources[1] = new ResourceFile("img/img2.png", "https://i.imgur.com/cN1hlHg_d.webp?maxwidth=760&fidelity=grand");
            _resources[2] = new ResourceFile("img/otval.gif", "https://i.imgur.com/Dv624zK.gif");
            _resources[3] = new ResourceFile("img/hug/img1.gif", "https://i.imgur.com/1oQ8Vt1.gif");
            //_resources[4] = new ResourceFile("img/hug/img2.gif", "https://i.imgur.com/Dv624zK.gif");

            if (!Directory.Exists("img"))
            {
                Directory.CreateDirectory("img");
                Directory.CreateDirectory("img/hug");
            }
            else
            {
                if (!Directory.Exists("img/hug"))
                {
                    Directory.CreateDirectory("img/hug");
                }
            }

            for (int i = 0; i < _resources.Length; i++)
            {
                if (!File.Exists(_resources[i].Path))
                {
                    client.DownloadFile(_resources[i].Url, _resources[i].Path);

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{_resources[i].Path} - не найден. скачиваю.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{_resources[i].Path} - Найден.");
                    Console.ResetColor();
                }
            }
        }
    }
}
