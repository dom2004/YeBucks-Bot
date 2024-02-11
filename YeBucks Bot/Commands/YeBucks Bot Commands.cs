using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Threading.Tasks;

namespace YeBucks_Bot.Commands
{
    public class YeBucks_Bot_Commands : BaseCommandModule
    {
        [Command("Test")]
        public async Task TestCommand(CommandContext context)
        {
            await context.Channel.SendMessageAsync("This is a test command.");
        }

        [Command("Ban")]
        [Description("Bans user from the server")]
        public async Task BanCommand(CommandContext context, DiscordMember member, [RemainingText] string reason)
        {
            await member.BanAsync(1, reason);
            await context.RespondAsync($"User {member.Username} was banned for {reason}.");
        }

        [Command("Vouch")]
        [Description("Vouches a seller")]
        public async Task VouchCommand(CommandContext context, DiscordMember member, string reason)
        {
            int score = 0;
            var message = new DiscordEmbedBuilder
            {
                Title = "New vouch created!",
                Description = $"Vouch Reason:\n {reason}\n\n Vouch\n Seller: {member.Mention}\n\n Vouch created by: {context.User.Mention}",
                Color = DiscordColor.Red,
                Timestamp = DateTime.Now,
                Footer = new DiscordEmbedBuilder.EmbedFooter
                {
                    Text = "Bot created by Legois"
                },
                Thumbnail = new DiscordEmbedBuilder.EmbedThumbnail
                {
                    Url = context.User.AvatarUrl
                }
            };
            await context.Channel.SendMessageAsync(embed: message);
        }

        [Command("Help")]
        [Description("Sends a list of commands")]
        public async Task HelpCommand(CommandContext context)
        {
            var message = new DiscordEmbedBuilder
            {
                Title = "Bot Commands",
                Description = "!ban [user] - bans specific user from server\n !vouch [seller] [reason] - adds a vouch to a specific seller you mention and gives them a vouch score\n More commands coming soon!",
                Color = DiscordColor.Black,
                
                Timestamp = DateTime.Now,
                Footer = new DiscordEmbedBuilder.EmbedFooter
                {
                    Text = "Bot created by Legois"
                },
            };
            await context.Channel.SendMessageAsync(embed: message);
        }
    }
}


