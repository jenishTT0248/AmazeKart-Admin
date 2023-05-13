using MassTransit;

namespace AmazeKart.User.API
{
    public class Startup
    {
        //public Startup(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //    StaticConfig = configuration;
        //}

        //public IConfiguration Configuration { get; }
        //public static IConfiguration StaticConfig { get; private set; }

        //private void ConfigureRabbitMQ(IBusRegistrationConfigurator x, string vHost, string userName, string password, AppSettings appSettings)
        //{
        //    x.UsingRabbitMq((context, cfg) =>
        //    {
        //        cfg.Host(new Uri(vHost), h =>
        //        {
        //            h.Username(userName);
        //            h.Password(password);

        //            if (appSettings.EnableBatchPublish)
        //            {
        //                //https://masstransit-project.com/usage/transports/rabbitmq.html#configurebatchpublish
        //                h.ConfigureBatchPublish(b =>
        //                {
        //                    b.Enabled = true;
        //                    b.Timeout = TimeSpan.FromMilliseconds(appSettings.BatchPublishTimeoutMilliseconds);
        //                });
        //            }

        //            if (appSettings.RabbitMQContinuationTimeout > 0)
        //            {
        //                h.ContinuationTimeout(TimeSpan.FromSeconds(appSettings.RabbitMQContinuationTimeout));
        //            }
        //        });

        //        cfg.UseNewtonsoftJsonSerializer();
        //        cfg.ConfigureEndpoints(context);
        //    });
        //}
    }
}
