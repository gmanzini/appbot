using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BOTapp.Modules;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;

namespace BOTapp
{
    class Program
    {
        private DiscordSocketClient _client;
        private CommandService _commands;
        private AudioService _audio;
        private IServiceProvider _services;
        public async Task RunBotAsync()
        {
            _client = new DiscordSocketClient();
            _commands = new CommandService();
            _audio = new AudioService();
            _services = new ServiceCollection()
                .AddSingleton(_client)
                .AddSingleton(_commands)
                .AddSingleton(_audio)
                .BuildServiceProvider();
            string token = "Njk2MzkzNzgxNzQxNzQ4MzI1.Xoqm0g.va6seX5r5-RsMdpLmhZ18d3XvkQ";
            _client.Log += _client_Log;
            await RegisterCommandAsync();
            await _client.LoginAsync(Discord.TokenType.Bot, token);
            await _client.StartAsync();
            
            await _client.SetGameAsync("=help // made by Manzini");
            await Task.Delay(-1);
        }

        private Task _client_Log(Discord.LogMessage arg)
        {
            Console.WriteLine(arg);
            return Task.CompletedTask;
        }

        public async Task RegisterCommandAsync()
        {
            _client.MessageReceived += HandleCommandAsync;
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
        }
        private async Task HandleCommandAsync(SocketMessage arg)
        {
            var message = arg as SocketUserMessage;
            var context = new SocketCommandContext(_client, message);
            if (message.Author.IsBot) return;

            int argPos = 0;
            if(message.HasStringPrefix("=",ref argPos))
            {
                var result = await _commands.ExecuteAsync(context, argPos, _services);
                if (!result.IsSuccess) Console.WriteLine(result.ErrorReason);
            }
        }
        static void Main(string[] args) => new Program().RunBotAsync().GetAwaiter().GetResult();

    }
}
