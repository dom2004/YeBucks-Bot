using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Threading.Tasks;

namespace YeBucks_Bot.Commands
{
    public class YeBucks_Bot_Commands : BaseCommandModule
    {
        [Command("Message")]
        [Description("Sends a set message.")]
        public async Task TestCommand(CommandContext context, DiscordChannel channel, params string[] message)
        {
            string allContents = string.Join(" ", message);
            var embed = new DiscordEmbedBuilder
            {
                Description = $"{allContents}",
                Color = DiscordColor.SpringGreen,
                Timestamp = DateTime.Now,
            };
            await channel.SendMessageAsync(embed: embed);

        }

        [Command("Ban")]
        [RequirePermissions(DSharpPlus.Permissions.BanMembers)]
        [Description("Bans user from the server")]
        public async Task BanCommand(CommandContext context, DiscordMember member, [RemainingText] string reason)
        {
            await member.BanAsync(1, reason);
            await context.RespondAsync($"User {member.Username} was banned for {reason}.");
        }

        [Command("Vouch")]
        [Description("Vouches a seller")]
        public async Task VouchCommand(CommandContext context, DiscordUser member, params string[] reason)
        {
            string allContents = string.Join(" ", reason);
            var message = new DiscordEmbedBuilder
            {
                Title = "New vouch created!",
                Description = $"Vouch Reason:\n {allContents}\n\n Vouch\n Seller: {member.Mention}\n\n Vouch created by: {context.User.Mention}",
                Color = DiscordColor.Red,
                Timestamp = DateTime.Now,
                ImageUrl = context.Message.Attachments[0].Url,
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
    }
}