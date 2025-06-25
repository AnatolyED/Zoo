namespace ZooApplicationConsole.Animals.Factory
{
    public interface IAnimalFactory
    {
        public string Key { get; }
        IAnimal CreateAnimal(string name, string animalSound);
    }
}
