namespace ZooApplicationConsole.Animals
{
    internal class Amphibian : Animal
    {
        public Amphibian(string name, string animalSound) : base(name, animalSound)
        {
            AnimalType = AnimalTypesEnum.Amphibian;
        }
    }
}
