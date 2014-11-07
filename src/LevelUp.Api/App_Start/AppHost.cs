using LevelUp.Api.LevelUp.Achievements;
using LevelUp.Api.LevelUp.Heroes;
using LevelUp.Database.Models;
using ServiceStack;

[assembly: WebActivator.PreApplicationStartMethod(typeof(LevelUp.Api.App_Start.AppHost), "Start")]


/**
 * Entire ServiceStack Starter Template configured with a 'Hello' Web Service and a 'Todo' Rest Service.
 *
 * Auto-Generated Metadata API page at: /metadata
 * See other complete web service examples at: https://github.com/ServiceStack/ServiceStack.Examples
 */

namespace LevelUp.Api.App_Start
{
    public class AppHost : AppHostBase
    {
        public AppHost() //Tell ServiceStack the name and where to find your web services
            : base("StarterTemplate ASP.NET Host", typeof(AchievementsService).Assembly) { }

        public override void Configure(Funq.Container container)
        {
            //Set JSON web services to return idiomatic JSON camelCase properties
            ServiceStack.Text.JsConfig.EmitCamelCaseNames = true;

            base.SetConfig(new HostConfig
                {
                    GlobalResponseHeaders =
                        {
                            { "Access-Control-Allow-Origin", "*" },
                            { "Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS" },
                            { "Access-Control-Allow-Headers", "Content-Type" }
                        }
                });
            //Configure User Defined REST Paths

            //Uncomment to change the default ServiceStack configuration
            //SetConfig(new HostConfig {
            //});

            //Enable Authentication
            //ConfigureAuth(container);

            //Register all your dependencies
            container.Register(new LevelUpContext());
            container.RegisterAutoWired<AchievementsRepository>();
            container.RegisterAutoWired<AchievementsService>();
            container.RegisterAutoWired<HeroService>();
            container.RegisterAutoWired<HeroesRepository>();
        }

        public static void Start()
        {
            new AppHost().Init();
        }
    }
}
