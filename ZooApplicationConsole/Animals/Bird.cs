namespace ZooApplicationConsole.Animals
{
    internal class Bird : Animal
    {
        public Bird(string name, string animalSound) : base(name, animalSound)
        {
            AnimalType = AnimalTypesEnum.Bird;
        }
    }
}
