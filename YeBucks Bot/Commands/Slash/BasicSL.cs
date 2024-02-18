using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using System;
using System.Threading.Tasks;

namespace YeBucks_Bot.Commands.Slash
{
    public class BasicSL : ApplicationCommandModule
    {
        [SlashCommand("Message", "Sends a message to a specific channel.")]
        [RequirePermissions(DSharpPlus.Permissions.Administrator)]
        public async Task MessageSlashCommand(InteractionContext context, [Option("Channel", "Choose a channel to send this message to.")] DiscordChannel chanel, [Option("Message", "Write your message here.")] string message)
        {
            await context.DeferAsync();

            string allContents = string.Join(" ", message);

            var embed = new DiscordEmbedBuilder
            {
                Title = "Prices",
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
        public async Task VouchSlashCommand(InteractionContext context, [Option("Seller", "Seller you want to vouch.")] DiscordUser member, [Option("Reason", "Write your vouch reason.")] string reason, [Option("Proof", "Send picture proof of service.")] DiscordAttachment image)
        {
            await context.DeferAsync();

            string allContents = string.Join(" ", reason);
            var emoji = DiscordEmoji.FromName(context.Client, "white_check_mark");

            var message = new DiscordEmbedBuilder
            {
                Title = "New vouch created!",
                Description = $"Vouch Reason:\n {allContents}\n\n Vouch\n Seller: {member.Mention}\n\n Vouch created by: {context.User.Mention}",
                Color = DiscordColor.Red,
                Timestamp = DateTime.Now,
                ImageUrl = image.FileName,
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

    }
}
