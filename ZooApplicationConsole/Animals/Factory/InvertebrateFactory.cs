namespace ZooApplicationConsole.Animals.Factory
{
    internal class InvertebrateFactory : IAnimalFactory
    {
        public string Key => "invertebrate";

        public IAnimal CreateAnimal(string name, string animalSound) => new Invertebrate(name, animalSound);
    }
}
