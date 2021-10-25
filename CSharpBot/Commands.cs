using Discord;
using Discord.WebSocket;
using System;
using System.Linq;

namespace CSharpBot
{
    class Commands
    {
        public void Hello(SocketMessage msg)
        {
            msg.Channel.SendMessageAsync($"Привет, {msg.Author}");
        }

        public void RandomNumber(SocketMessage msg)
        {
            Random rnd = new();
            //msg.AddReactionAsync(new Emoji("\U0001f495"));
            msg.Channel.SendMessageAsync($"Выпало число {rnd.Next(0, 100)}");
        }

        public void Help(SocketMessage msg)
        {
            msg.Channel.SendMessageAsync(".\n Hi! All bot commands : \n !roll - roll random number (0, 100) \n !author - info about me.");
        }

        public void Author(SocketMessage msg)
        {
            msg.Channel.SendMessageAsync(".\n Hi! I'm Alexander, I'm 14 y.o. \n Links : \n GitHub : https://github.com/MrOkun \n VK : https://vk.com/alexklush \n My programs : \n !dither - dither algorithm \n !otval - effect of video card crash \n !portal-closer - spigot plugin");
        }

        public void DitherImage(SocketMessage msg)
        {
            var beforImg = @"img/img1.png";
            var afterImg = @"img/img2.png";

            msg.Channel.SendFileAsync(beforImg, "Before Dither");
            msg.Channel.SendFileAsync(afterImg, "After Dither");
        }

        public void Otval(SocketMessage msg)
        {
            var otvalGif = @"img/otval.gif";

            msg.Channel.SendFileAsync(otvalGif, "Otval");
        }

        public void PortalCloser(SocketMessage msg)
        {
            var PortalCloserLink = "https://www.youtube.com/watch?v=1PsV6OlIjJE";

            msg.Channel.SendMessageAsync($"Link to video example : {PortalCloserLink}");
        }
    }
}