namespace ZooApplicationConsole.Animals.Factory
{
    internal class BirdFactory : IAnimalFactory
    {
        public string Key => "bird";
        public IAnimal CreateAnimal(string name, string animalSound) => new Bird(name, animalSound);
    }
}
