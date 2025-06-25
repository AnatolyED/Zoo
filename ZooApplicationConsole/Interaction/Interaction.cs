using ZooApplicationConsole.Data;
using ZooApplicationConsole.Functional;

namespace ZooApplicationConsole.UserInteraction
{
    public class Interaction
    {
        private readonly Actions _actions;

        public Interaction(Actions actions) => _actions = actions;

        public async Task Startup(CancellationTokenSource cts)
        {
            var menu = Task.Run(() => RunMenu(cts.Token), cts.Token);

            await menu;
            cts.Cancel();
        }

        private async Task RunMenu(CancellationToken ct)
        {
            bool exit = false;

            while (!exit && !ct.IsCancellationRequested) 
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("------ Меню ------");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine
                    (
                    "\n" +
                    "1. Добавить животное\n" +
                    "2. Покормить животное\n" +
                    "3. Посмотреть всех животных\n" +
                    "4. Выход из программы\n" +
                    "\n" +
                    "Выберите операцию:" 
                    );
                Console.ForegroundColor = ConsoleColor.Blue;

                string? input = Console.ReadLine();
                
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("------ Результат ------");

                switch (input) 
                {
                    case "1":
                        _actions.CreateAnimal();
                        break;
                    case "2":
                        _actions.FeedAnimal();
                        break;
                    case "3":
                        _actions.WatchAnimalsList();
                        break;
                    case "4":
                        Console.WriteLine("Завершение работы...");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Неизвестная команда. Попробуйте снова.");
                        break;
                }
            }
        }
    }
}
