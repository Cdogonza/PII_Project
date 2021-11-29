using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
//--------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

namespace ClassLibrary
{
    /// <summary>
    /// Un programa que implementa un bot de Telegram.
    /// </summary>
    public static class Program
    {
        // La instancia del bot.
        private static TelegramBotClient Bot;

        // El token provisto por Telegram al crear el bot.
        //
        // *Importante*:
        // Para probar este ejemplo, crea un bot nuevo y eeemplaza este token por el de tu bot.
        //private static string Token = "2133513418:AAHIE7L6s-OQSi6BroKBheNa-JGIXAlsMR0";
        //private static string Token = "2099808385:AAGebOzNFY6kA5hwEY2XJbOJxZBzWAIM8U0";
        //private static string Token = "2133499409:AAFKS9VqLu7UXqQccvTHFFzcIvxwEoCGtkM"; //
        //private static string Token = "2105636402:AAG6BbtW--SQ0pVOOpRKcHQQJTl7rwFWRxA";       // Belu
        private static string Token = "2143110246:AAFxnNCvWemFWzsitJkRwkVE63yHdJDgI_k";
        private static IHandler firstHandler;

        /// <summary>
        /// Punto de entrada al programa.
        /// </summary>
        public static void Main()
        {
            Bot = new TelegramBotClient(Token);

            firstHandler =
                new WelcomeHandler(
                new CancellationHandler(
                new RegistrationHandler(              
                new DataManagerHandler(
                new MaterialTypesHandler(
                new PublicationHandler(
                new BuyerOfferHandler(                                
                new PermissionsHandler(
                new AreaOfWorkHandler(  
                new SearchOffersHandler(  
                new CloseSessionHandler(                             
                new MapsHandler(Bot,null))))))))))));
            Message message = new Message();
           

            var cts = new CancellationTokenSource();

            // Comenzamos a escuchar mensajes. Esto se hace en otro hilo (en background). El primer método
            // HandleUpdateAsync es invocado por el bot cuando se recibe un mensaje. El segundo método HandleErrorAsync
            // es invocado cuando ocurre un error.
            Bot.StartReceiving(
                new DefaultUpdateHandler(HandleUpdateAsync, HandleErrorAsync),
                cts.Token
            );

            // Esperamos a que el usuario aprete Enter en la consola para terminar el bot.
            Console.ReadLine();

            // Terminamos el bot.
            cts.Cancel();
        }

        /// <summary>
        /// Maneja las actualizaciones del bot (todo lo que llega), incluyendo mensajes, ediciones de mensajes,
        /// respuestas a botones, etc. En este ejemplo sólo manejamos mensajes de texto.
        /// </summary>
        public static async Task HandleUpdateAsync(Update update, CancellationToken cancellationToken)
        {
            try
            {
                // Sólo respondemos a mensajes de texto
                if (update.Type == UpdateType.Message)
                {
                    await HandleMessageReceived(new TelegramMsgAdapter(update.Message));
                }
            }
            catch(Exception e)
            {
                await HandleErrorAsync(e, cancellationToken);
            }
        }

        /// <summary>
        /// Maneja los mensajes que se envían al bot.
        /// Lo único que hacemos por ahora es escuchar 3 tipos de mensajes:
        /// - "hola": responde con texto
        /// - "chau": responde con texto
        /// - "foto": responde con una foto
        /// </summary>
        /// <param name="message">El mensaje recibido</param>
        /// <returns></returns>
        private static async Task HandleMessageReceived(IMessage message)
        {
            Console.WriteLine($"Received a message from {message.FirstName} saying: {message.Text}");

            string response = string.Empty;

            firstHandler.Handle(message, out response);

            if (!string.IsNullOrEmpty(response))
            {
                await Bot.SendTextMessageAsync(message.ChatId, response);
            }
        }

        /// <summary>
        /// Manejo de excepciones. Por ahora simplemente la imprimimos en la consola.
        /// </summary>
        public static Task HandleErrorAsync(Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine(exception.Message);
            return Task.CompletedTask;
        }
    }
 }