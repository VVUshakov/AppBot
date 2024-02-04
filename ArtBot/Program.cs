using Telegram.Bot;


const string YOUR_ACCESS_TOKEN_HERE = "5444180316:AAGOxZcjbNWrf7uyCtTJ7nTVlG_zE4MIU44";
var botClient = new TelegramBotClient(YOUR_ACCESS_TOKEN_HERE);

var me = await botClient.GetMeAsync();
Console.WriteLine($"Hello, World! I am user {me.Id} and my name is {me.FirstName}.");
