using DSharpPlus;
using DSharpPlus.CommandsNext;
using System.Threading.Tasks;
using YeBucks_Bot.Commands;
using YeBucks_Bot.Config;

namespace YeBucks_Bot
{
    internal class Program
    {
        private static DiscordClient Client { get; set; }
        private static CommandsNextExtension Commands { get; set; }
        static async Task Main(string[] args)
        {
            var JsonReader = new JSONreader();
            await JsonReader.ReadJSON();

            var DiscordConfig = new DiscordConfiguration()
            {
                Intents = DiscordIntents.All,
                Token = JsonReader.token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
            };


            Client = new DiscordClient(DiscordConfig);

            var commandsConfig = new CommandsNextConfiguration()
            {
                StringPrefixes = new string[] { JsonReader.prefix },
                EnableMentionPrefix = true,
                EnableDms = true,
                EnableDefaultHelp = false,
                
            };

            Commands = Client.UseCommandsNext(commandsConfig);

            Commands.RegisterCommands<YeBucks_Bot_Commands>();


            await Client.ConnectAsync();
            await Task.Delay(-1);

        }

        private static Task ClientReady(DiscordClient sender, DSharpPlus.EventArgs.ReadyEventArgs args)
        {
            return Task.CompletedTask;
        }
    }
}

