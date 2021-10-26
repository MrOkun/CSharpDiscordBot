using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace CSharpBot
{
    class Program
    {
        static private Commands Commands;
        static private Configurator Configurator;
        static private Resource Resource;
        private DiscordSocketClient _client;
        private const string _special_Character = "!";

        static void Main(string[] args)
        {
            start:

            Commands = new Commands();
            Configurator = new Configurator();
            Resource = new Resource();
            Configurator.Start();
            Resource.Check();

            try
            {
                new Program().MainAsync().GetAwaiter().GetResult();
            }
            catch (Discord.Net.HttpException e)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Возможно токен был введён не верно. Ошибка - {e}");
                Console.ResetColor();
                goto start;
            }
            catch (System.Net.Http.HttpRequestException e)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Возможно токен был введён не верно. Ошибка - {e}");
                Console.ResetColor();
                goto start;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Произошла непредвиденная ошибка - {e}");
                Console.ResetColor();
                goto start;
            }
        }

        public async Task HandleReactionAddedAsync(Cacheable<IUserMessage, ulong> cachedMessage, ISocketMessageChannel originChannel, SocketReaction reaction)
        {

        }

        private async Task MainAsync()
        {
            _client = new DiscordSocketClient();
            _client.MessageReceived += CommandsHandler;
            _client.ReactionAdded += HandleReactionAddedAsync;
            _client.Log += Log;

            var token = Configurator.TokenRead();

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            Console.ReadLine();
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        private Task CommandsHandler(SocketMessage msg)
        {
            if (!msg.Author.IsBot)
                if (msg.Content.Contains("neck"))
                {
                    Commands.Neck(msg);
                }
                else
                {
                    switch (msg.Content)
                    {
                        case _special_Character + "help":
                            {
                                Commands.Help(msg);
                                break;
                            }
                        case _special_Character + "author":
                            {
                                Commands.Author(msg);
                                break;
                            }
                        case _special_Character + "roll":
                            {
                                Commands.RandomNumber(msg);
                                break;
                            }
                        case _special_Character + "dither":
                            {
                                Commands.DitherImage(msg);
                                break;
                            }
                        case _special_Character + "otval":
                            {
                                Commands.Otval(msg);
                                break;
                            }
                        case _special_Character + "portal-closer":
                            {
                                Commands.PortalCloser(msg);
                                break;
                            }
                        case _special_Character + "emoji":
                            {
                                Commands.Emoji(msg);
                                break;
                            }
                    }
                }
                
            return Task.CompletedTask;
        }
    }
}