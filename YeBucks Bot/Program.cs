using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Enums;
using DSharpPlus.Interactivity.Extensions;
using DSharpPlus.SlashCommands;
using System;
using System.Threading.Tasks;
using YeBucks_Bot.Commands;
using YeBucks_Bot.Commands.Slash;
using YeBucks_Bot.Config;

namespace YeBucks_Bot
{
    internal class Program
    {
        public static DiscordClient Client { get; private set; }
        private static InteractivityExtension Interactivity { get; set; }
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

            Client.UseInteractivity(new InteractivityConfiguration()
            {
                PollBehaviour = PollBehaviour.KeepEmojis,
                Timeout = TimeSpan.FromSeconds(30)
            });

            var commandsConfig = new CommandsNextConfiguration()
            {
                StringPrefixes = new string[] { JsonReader.prefix },
                EnableMentionPrefix = true,
                EnableDms = true,
                EnableDefaultHelp = true,
                
            };

            Commands = Client.UseCommandsNext(commandsConfig);

            var slashCommandConfig = Client.UseSlashCommands();

            Commands.RegisterCommands<YeBucks_Bot_Commands>();

            slashCommandConfig.RegisterCommands<BasicSL>();


            await Client.ConnectAsync();
            await Task.Delay(-1);


        }

        private static Task ClientReady(DiscordClient sender, DSharpPlus.EventArgs.ReadyEventArgs args)
        {
            return Task.CompletedTask;
        }

    }
}

