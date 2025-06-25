namespace ZooApplicationConsole.Animals
{
    internal class Mammals : Animal
    {
        public Mammals(string name, string animalSound) : base(name, animalSound)
        {
            AnimalType = AnimalTypesEnum.Mammals;
        }
    }
}
