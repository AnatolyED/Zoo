namespace ZooApplicationConsole.Animals
{
    public interface IAnimal
    {
        public string Name { get; }
        public int Energy { get; }

        public abstract void PlaySound();
        public abstract void TakeFood();
    }
}
