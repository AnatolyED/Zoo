using System.Text;
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
            Console.Write("Выберите тип животного: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(sb.ToString());
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Ваш тип: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            var animalType = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Введите имя животного: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            var name = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Введите звук вашего животного: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            var sound = Console.ReadLine();

            if (
                string.IsNullOrWhiteSpace(animalType) ||
                string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(sound)
                )
                Console.WriteLine(
                    "Какой-то из параметров был указан неверно!\n" +
                    "Поля не должны быть пустыми или состоять из одних пробелов.\n" +
                    "Попробуйте снова с другими параметрами."
                    );
            else
            {
                var factory = _factoryProvider.GetFactoryByKey(animalType);
                if (factory == null) return;

                var animal = factory?.CreateAnimal(name, sound);
                _animalsData.AddNewAnimal(animal);
                Console.WriteLine("Животное успешно добавленно в вашу коллекцию");
            }
        }
        public void FeedAnimal() 
        {
            WatchAnimalsList();

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Выберите животное, которое хотите покормить: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            
             int num;
            var animals = _animalsData.GetAnimals();
            
            if (int.TryParse(Console.ReadLine(), out num) 
                && num <= animals.Count
                && num > 0)
            {
                num -= 1;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(
                    $"Вы выбрали: {animals[num].Name}\n" +
                    $"Его энергия: {animals[num].Energy}\n");

                Console.ForegroundColor = ConsoleColor.DarkGreen; 
                animals[num].TakeFood();
                Console.WriteLine($"Энергия после кормления: {animals[num].Energy}\n");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка! Неверено указанно животное, попробуйте снова.");
            }
                    
        }
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
