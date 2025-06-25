using Microsoft.Extensions.DependencyInjection;
using System.Text;
using System.Text.Json;
using ZooApplicationConsole.Animals;
using ZooApplicationConsole.Animals.Factory;
using ZooApplicationConsole.Data;

namespace ZooApplicationConsole.Functional
{
    public class Actions
    {
        private readonly AnimalsData _animalsData;
        private readonly AnimalFactoryProvider _factoryProvider;

        public Actions
            (
            AnimalsData animalsData,
            AnimalFactoryProvider factoryProvider
            )
        {
            _animalsData = animalsData;
            _factoryProvider = factoryProvider;
        }

        public void CreateAnimal()
        {
            StringBuilder sb = new StringBuilder();
            var values = Enum.GetValues(typeof(AnimalTypesEnum));
            
            foreach(var value in values )
                sb.AppendLine(value.ToString());   


            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Выберите тип животного:");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(sb.ToString());
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Ваш тип:");
            Console.ForegroundColor = ConsoleColor.Blue;
            var animalType = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Введите имя животного:");
            Console.ForegroundColor = ConsoleColor.Blue;
            var name = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Введите звук вашего животного:");
            Console.ForegroundColor = ConsoleColor.Blue;
            var sound = Console.ReadLine();

            if (animalType == null || name == null || sound == null)
                Console.WriteLine(
                    "Какой-то из параметров был указан неверно!\n" +
                    "Попробуйте снова с другими параметрами."
                    );
            else
            {
                var factory = _factoryProvider.GetFactoryByKey(animalType);
                var animal = factory?.CreateAnimal(name, sound);
                _animalsData.AddNewAnimal(animal);

                Console.WriteLine("Животное успешно добавленно в вашу коллекцию");
            }
        }
        public void FeedAnimal() { }
        public void WatchAnimalsList() 
        {
            StringBuilder sb = new StringBuilder();
            var animals = _animalsData.GetAnimals();

            if (animals.Count > 0)
            {
                for (int i = 0; i < animals.Count; i++)
                {
                    var animal = animals[i];
                    sb.AppendLine($"{i+1}. Имя: {animal.Name}");
                }

                Console.WriteLine(sb.ToString());
            }
            else
            {
                Console.WriteLine("Ваш список животны пуст!");
            }
        }
    }
}
