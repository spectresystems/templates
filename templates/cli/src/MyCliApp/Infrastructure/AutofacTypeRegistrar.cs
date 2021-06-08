using System;
using Autofac;
using Spectre.Console.Cli;

namespace MyCliApp
{
    public sealed class AutofacTypeRegistrar : ITypeRegistrar
    {
        private readonly ContainerBuilder _builder;

        public AutofacTypeRegistrar(ContainerBuilder builder)
        {
            _builder = builder;
        }

        public ITypeResolver Build()
        {
            return new AutofacTypeResolver(_builder.Build());
        }

        public void Register(Type service, Type implementation)
        {
            _builder.RegisterType(implementation).As(service);
        }

        public void RegisterInstance(Type service, object implementation)
        {
            _builder.RegisterInstance(implementation).As(service);
        }
    }
}
