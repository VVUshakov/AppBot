﻿namespace ArtBot.Services.Bot.VK
{
    public class VKBot : IBotService
    {
        public Task StartAsync()
        {
            //TODO: заглушка

            Console.WriteLine("VKBot запущен.");
            return Task.CompletedTask;
        }
    }
}