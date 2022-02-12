using Spectre.Console.Cli;

namespace MyCliApp;

public static class Program
{
    public static int Main(string[] args)
    {
        var app = new CommandApp();
        app.Configure(config =>
        {
            config.SetApplicationName("MyCliApp");
            config.UseStrictParsing();
        });

        return app.Run(args);
    }
}
