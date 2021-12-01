using AOC2021.Days;

namespace AOC2021
{
    public abstract class BaseTask<T> : ITask
    {

        public abstract string InputFileName { get; }
        public abstract Func<string, T> InputParser { get; }
        public IList<T> Inputs { get; set; } = new List<T>();

        protected void ParseInput()
        {
            Inputs = Utils.ReadFile(InputFileName, InputParser);
        }
        protected abstract string HandleInput();

        public void Run()
        {
            Console.WriteLine("Parsing input...");
            ParseInput();

            Console.WriteLine("Calculating result...");
            var result = HandleInput();

            Console.WriteLine("Result: "+ result);

        }

    }
}
