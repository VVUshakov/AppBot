﻿namespace ArtBot.Services.Bot.WhatsApp
{
    public class WhatsAppBot : IBotService
    {
        public Task StartAsync()
        {
            //TODO: заглушка

            Console.WriteLine("WhatsAppBot запущен.");
            return Task.CompletedTask;
        }
    }
}