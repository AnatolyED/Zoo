namespace ZooApplicationConsole.Animals.Factory
{
    public class ReptilesFactory : IAnimalFactory
    {
        public string Key => "reptiles";

        public IAnimal CreateAnimal(string name, string animalSound) => new Reptiles(name, animalSound);
    }
}
