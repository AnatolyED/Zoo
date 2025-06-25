namespace ZooApplicationConsole.Animals
{
    public class Animal : IAnimal
    {
        protected string _animalSound = "Неизвестный звук";
        public AnimalTypesEnum AnimalType;
        public string Name { get; private set; }
        public int Energy { get; private set; }
        
        public Animal(string name, string animalSound)
        {
            Name = name;
            _animalSound = animalSound;
            Energy = new Random().Next(0, 101);
        }

        public Animal(string name)
        {
            Name = name;
        }

        public virtual void PlaySound()
        {
            Console.WriteLine($"{Name} издал звук: {_animalSound}");
        }

        public virtual void TakeFood()
        {
            Energy = Energy + 5 <= 100 ? Energy += 5 : Energy = 100;

            Console.WriteLine($"Вы покормили {Name} и восполнили 5 энергии\n" +
                $"Энергия животного: {Energy}");
        }
    }
}
