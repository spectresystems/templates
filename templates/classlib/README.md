# MyClassLib

Add some descriptive text about this library here.

## Running examples

To see `MyClassLib` in action, install the 
[dotnet-example](https://github.com/patriksvensson/dotnet-example)
global tool.

```
> dotnet tool install -g dotnet-example
```

Now you can list available examples in this repository:

```
> dotnet example

╭─────────┬─────────────────────────────────┬─────────────╮
│ Name    │ Path                            │ Description │
├─────────┼─────────────────────────────────┼─────────────┤
│ Example │ examples/Example/Example.csproj │ N/A         │
╰─────────┴─────────────────────────────────┴─────────────╯
```

## Building

We're using [Cake](https://github.com/cake-build/cake) as a 
[dotnet tool](https://docs.microsoft.com/en-us/dotnet/core/tools/global-tools) 
for building. So make sure that you've restored Cake by running 
the following in the repository root:

```
> dotnet tool restore
```

After that, running the build is as easy as writing:

```
> dotnet cake
```

## Copyright

Copyright (c) 2020 Spectre Systems AB