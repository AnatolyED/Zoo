namespace ZooApplicationConsole.Animals.Factory
{
    internal class AmphibianFactory : IAnimalFactory
    {
        public string Key => "amphibian";
        public IAnimal CreateAnimal(string name, string animalSound) => new Amphibian(name, animalSound);
    }
}
