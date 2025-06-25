namespace ZooApplicationConsole.Animals.Factory
{
    internal class MammalsFactory : IAnimalFactory
    {
        public string Key => "mammals";

        public IAnimal CreateAnimal(string name, string animalSound) => new Mammals(name, animalSound);
    }
}
