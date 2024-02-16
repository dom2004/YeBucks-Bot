using DSharpPlus.SlashCommands;
using System.Threading.Tasks;
using DSharpPlus.Entities;
using DSharpPlus;
using System;
using System.Threading.Channels;
using DSharpPlus.CommandsNext.Attributes;

namespace YeBucks_Bot.Commands.Slash
{
    public class BasicSL : ApplicationCommandModule
    {
        [SlashCommand("Mesage", "Sends a message to a specific channel.")]
        public async Task MessageSlashCommand(InteractionContext context, [Option("Chanel", "Choose a channel to send this message to.")] DiscordChannel chanel, [Option("Message", "Write your message here.")] string message)
        {
            await context.DeferAsync();

            string allContents = string.Join(" ", message);

            var embed = new DiscordEmbedBuilder
            {
                Description = $"{allContents}",
                Color = DiscordColor.SpringGreen,
                Timestamp = DateTime.Now,
            };

            var embed2 = new DiscordEmbedBuilder
            {
                Description = "Message successfully sent",
                Color = DiscordColor.SpringGreen,
                Timestamp = DateTime.Now,
            };

            await context.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(embed2));

            await chanel.SendMessageAsync(embed: embed);
        }

        [SlashCommand("Vouch", "Vouches a specified seller.")]
        public async Task VouchSlashCommand(InteractionContext context, [Option("Seller", "Seller you want to vouch.")] DiscordUser member, [Option("Reason", "Write your vouch reason.")] string reason)
        {
            await context.DeferAsync();

            string allContents = string.Join(" ", reason);
            var message = new DiscordEmbedBuilder
            {
                Title = "New vouch created!",
                Description = $"Vouch Reason:\n {allContents}\n\n Vouch\n Seller: {member.Mention}\n\n Vouch created by: {context.User.Mention}",
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

            await context.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(message));
        }

        [SlashCommand("Ban", "Bans a specific user from the server.")]
        [RequirePermissions(DSharpPlus.Permissions.BanMembers)]
        public async Task BanSlashCommand(InteractionContext context, [Option("User", "User you want to ban from the server.")] DiscordUser member, [Option("Reason", "Reason for ban.")] string reason)
        {
            await context.DeferAsync();
            await context.Guild.BanMemberAsync(member,1,reason);
            await context.EditResponseAsync(new DiscordWebhookBuilder().WithContent($"User {member.Username} was banned for {reason}."));
        }
    }
}
