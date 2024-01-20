namespace Challenges.Commands
{
    internal class SumCommandHandler : ICommandHandler
    {
        public string Execute(string[] args)
        {
            decimal sum = 0;
            foreach (var arg in args)
            {
                decimal value;
                if (!decimal.TryParse(arg, out value))
                    return $"Error. Could not convert {arg}.";
                sum += value;
            }

            return sum.ToString();
        }
    }
}
