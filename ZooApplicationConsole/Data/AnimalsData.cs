using ZooApplicationConsole.Animals;

namespace ZooApplicationConsole.Data
{
    public class AnimalsData
    {
        private List<IAnimal> _animals = new List<IAnimal>();

        public List<IAnimal> GetAnimals()
        {
            var animals = _animals.ToList();
            return animals;
        }
        public void AddNewAnimal(IAnimal animal) => _animals.Add(animal);
        public void RemoveAnimal() 
        {
            
        }
    }
}
