namespace ZooApplicationConsole.Animals.Factory
{
    public class AnimalFactoryProvider
    {
        private readonly Dictionary<string, IAnimalFactory> _factoryMap;

        public AnimalFactoryProvider(IEnumerable<IAnimalFactory> factories) => _factoryMap = factories.ToDictionary(f => f.Key, f => f);
        public IAnimalFactory? GetFactoryByKey(string key)
        {
            var normalizedKey = key.Trim().ToLowerInvariant();
            var factory = _factoryMap.FirstOrDefault(f => f.Key.ToLowerInvariant() == normalizedKey).Value;

            if (factory != null) return factory;
            else
            {
                Console.WriteLine(
                    "Вы указали несуществующий тип.\n" +
                    "Будте внимательный и попробуйте снова.");

                return null;
            }
        }
    }
}
