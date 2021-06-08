using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Spectre.Console;
using Spectre.Console.Cli;

namespace MyCliApp
{
    public sealed class DummyCommand : Command<DummyCommand.Settings>
    {
        private readonly IAnsiConsole _console;
        private readonly IGreeter _greeter;

        public sealed class Settings : CommandSettings
        {
            [CommandArgument(0, "<NAME>")]
            [Description("Your name")]
            public string Name { get; }

            [CommandOption("-n|--number <NUMBER>")]
            [Description("An optional number")]
            public int? Number { get; set; }

            [CommandOption("-f|--flag")]
            [Description("An optional flag")]
            public bool Flag { get; set; }

            public Settings(string name)
            {
                Name = name ?? throw new ArgumentNullException(nameof(name));
            }
        }

        public DummyCommand(IAnsiConsole console, IGreeter greeter)
        {
            _console = console ?? throw new ArgumentNullException(nameof(console));
            _greeter = greeter ?? throw new ArgumentNullException(nameof(greeter));
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings)
        {
            if (settings is null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            _console.Render(new Table()
                .RoundedBorder()
                .Title(_greeter.Greet(settings.Name))
                .BorderColor(Color.Yellow)
                .AddColumns("Setting", "Value")
                .AddRow("Text", settings.Name)
                .AddRow("Number", settings.Number?.ToString(CultureInfo.InvariantCulture) ?? "?")
                .AddRow("Flag", settings.Flag.ToString()));

            return 0;
        }
    }
}
