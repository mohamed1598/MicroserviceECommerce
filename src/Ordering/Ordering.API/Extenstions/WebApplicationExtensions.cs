using Ordering.API.RabbitMQ;

namespace Ordering.API.Extenstions
{
    public static class WebApplicationExtensions
    {
        public static EventBusRabbitMQConsumer? Listener { get; set; }
        public static WebApplication UseRabbitListener(this WebApplication app)
        {
            Listener = app.Services.GetService<EventBusRabbitMQConsumer>();
            var life = app.Services.GetService<IHostApplicationLifetime>();

            life.ApplicationStarted.Register(OnStarted);
            life.ApplicationStopping.Register(OnStopping);

            return app;
        }

        private static void OnStarted()
        {
            Listener!.Consume();
        }

        private static void OnStopping()
        {
            Listener!.Disconnect();
        }
    }
}
