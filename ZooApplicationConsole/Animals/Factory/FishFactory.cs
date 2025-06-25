namespace ZooApplicationConsole.Animals.Factory
{
    internal class FishFactory : IAnimalFactory
    {
        public string Key => "fish";
        public IAnimal CreateAnimal(string name, string animalSound) => new Fish(name, animalSound);
    }
}
