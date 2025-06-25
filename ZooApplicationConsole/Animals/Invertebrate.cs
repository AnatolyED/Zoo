namespace ZooApplicationConsole.Animals
{
    internal class Invertebrate : Animal
    {
        public Invertebrate(string name, string animalSound) : base(name, animalSound)
        {
            AnimalType = AnimalTypesEnum.Invertebrate;
        }
    }
}
