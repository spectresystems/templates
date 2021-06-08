using Autofac;
using Spectre.Console.Cli;

namespace MyCliApp
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            var registrar = CreateRegistrar();

            var app = new CommandApp(registrar);
            app.Configure(config =>
            {
                config.SetApplicationName("MyCliApp");
                config.UseStrictParsing();

                config.AddCommand<DummyCommand>("dummy");
            });

            return app.Run(args);
        }

        private static ITypeRegistrar CreateRegistrar()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Greeter>().As<IGreeter>();
            return new AutofacTypeRegistrar(builder);
        }
    }
}
