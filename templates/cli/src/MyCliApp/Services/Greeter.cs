namespace MyCliApp
{
    public interface IGreeter
    {
        string Greet(string name);
    }

    public sealed class Greeter : IGreeter
    {
        public string Greet(string name)
        {
            return $"Hello {name}!";
        }
    }
}
