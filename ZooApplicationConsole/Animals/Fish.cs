namespace ZooApplicationConsole.Animals
{
    internal class Fish : Animal
    {

        public Fish(string name, string animalSound) : base(name, animalSound)
        {
            AnimalType = AnimalTypesEnum.Fish;
        }
    }
}
