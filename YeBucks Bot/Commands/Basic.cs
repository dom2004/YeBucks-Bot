using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Interactivity.Extensions;
using System.Threading.Tasks;

namespace YeBucks_Bot.Commands
{
    public class Basic : BaseCommandModule
    {
        [Command("Test")]
        public async Task TestCommand(CommandContext context)
        {
            var interactivity = Program.Client.GetInteractivity();

            var messageToRetrieve = await interactivity.WaitForMessageAsync(message => message.Content == "Hello");
        }
    }
}
