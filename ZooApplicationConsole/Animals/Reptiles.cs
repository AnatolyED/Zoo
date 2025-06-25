namespace ZooApplicationConsole.Animals
{
    internal class Reptiles : Animal
    {
        public Reptiles(string name, string animalSound) : base(name, animalSound)
        {
            AnimalType = AnimalTypesEnum.Reptiles;
        }
    }
}
