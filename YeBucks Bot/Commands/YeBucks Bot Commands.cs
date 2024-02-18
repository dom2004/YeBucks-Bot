using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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
                Title = "Prices",
                Description = $"{allContents}",
                Color = DiscordColor.SpringGreen,
                Timestamp = DateTime.Now,
                Thumbnail = new DiscordEmbedBuilder.EmbedThumbnail
                {
                    Url = "https://media.discordapp.net/attachments/758773973327675423/1195891861856985228/5206272.png?ex=65e3c896&is=65d15396&hm=b887bd90389272bdf4daa1b963b0bec0734f9852f1beb8a9c2465ee4e8c6768f&=&format=webp&quality=lossless&width=468&height=468"
                }
            };

            var embed2 = new DiscordEmbedBuilder
            {
                Description = "Message successfully sent",
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

        [Command("Prices")]
        [Description("Prices for the services.")]
        public async Task PricesCommand(CommandContext context)
        {
            var message = new DiscordEmbedBuilder
            {
                Title = "Prices",
                Description = "$15 for 10K V-Bucks\n $19 for 13.5K V-Bucks\n $33 for 27K V-Bucks\n $43 for 40K V-Bucks\n $3 for Crew Pack\n\n Yoshi Payment Methods:\n Cashapp\n Paypal\n Zelle\n Crypto\n Revolut\n Doordash GiftCard(Once per customer)\n\n Ye Payment Methods:\n Cashapp\n Paypal\n Crypto\n\n Gift Service:\n $1 - 500 V-Buck Gift\n $2 - 800 V-Buck Gift\n $3 - 1200 V-Buck Gift\n $4 - 1500 V-Buck Gift\n $5 - 2000 V-Buck Gift",
                Timestamp = DateTime.Now,
                Color = DiscordColor.SpringGreen,
                Footer = new DiscordEmbedBuilder.EmbedFooter
                {
                    Text = "Bot created by Legois"
                },
                Thumbnail = new DiscordEmbedBuilder.EmbedThumbnail
                {
                    Url = "https://media.discordapp.net/attachments/758773973327675423/1195891861856985228/5206272.png?ex=65e3c896&is=65d15396&hm=b887bd90389272bdf4daa1b963b0bec0734f9852f1beb8a9c2465ee4e8c6768f&=&format=webp&quality=lossless&width=468&height=468"
                },
            };
            await context.Channel.SendMessageAsync(embed: message);
        }
    }
}