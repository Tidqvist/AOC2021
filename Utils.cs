
namespace AOC2021
{
    public class Utils
    {
        public static IList<T> ReadFile<T>(string fileName, Func<string, T> parse)
        {
            string[] lines = File.ReadAllLines($"../../../Data/{fileName}.txt");

            return lines.Select(x => parse(x))
                .ToList();
        }

        public static ITask GetLatestTaskInAssembly()
        {
            var tasks = GetAllTaskInAssembly();
            var latest = tasks.OrderByDescending(x => x.GetType().Name).First();
            return latest;
        }

        public static IList<ITask> GetAllTaskInAssembly()
        {
            var taskTypes = AppDomain.CurrentDomain.GetAssemblies()
                .ToList()
                .SelectMany(x => x.GetTypes())
                .Where(t => typeof(ITask).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract)
                .ToList();

            var instanciatedTasks = taskTypes.Select(x => Activator.CreateInstance(x) as ITask)
                .Where(x => x != null)
                .ToList();

            return instanciatedTasks!;
        }
    }

}
