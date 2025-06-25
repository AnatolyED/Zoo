using Microsoft.Extensions.DependencyInjection;
using ZooApplicationConsole.Animals.Factory;
using ZooApplicationConsole.Data;
using ZooApplicationConsole.Functional;
using ZooApplicationConsole.UserInteraction;

namespace ZooApplicationConsole
{
    public class Program
    {
        static async Task Main()
        {
            var cts = new CancellationTokenSource();
            var services = new ServiceCollection();

            services.AddSingleton<IAnimalFactory, AmphibianFactory>();
            services.AddSingleton<IAnimalFactory, BirdFactory>();
            services.AddSingleton<IAnimalFactory, FishFactory>();
            services.AddSingleton<IAnimalFactory, InvertebrateFactory>();
            services.AddSingleton<IAnimalFactory, MammalsFactory>();
            services.AddSingleton<IAnimalFactory, ReptilesFactory>();

            services.AddSingleton<AnimalFactoryProvider>();
            services.AddSingleton<AnimalsData>();
            services.AddTransient<Actions>();
            services.AddTransient<Interaction>();

            var serviceProvider = services.BuildServiceProvider();
            var interaction = serviceProvider.GetRequiredService<Interaction>();

            try
            { 
                await interaction.Startup(cts);
            }
            finally
            {
                Console.ResetColor();
                Console.WriteLine("Программа закончила свою работу.");
            }
        }
    }
}
