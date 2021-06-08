using System;
using Autofac;
using Spectre.Console.Cli;

namespace MyCliApp
{
    public sealed class AutofacTypeResolver : ITypeResolver
    {
        private readonly ILifetimeScope _scope;

        public AutofacTypeResolver(ILifetimeScope scope)
        {
            _scope = scope;
        }

        public object? Resolve(Type? type)
        {
            if (type == null)
            {
                return type;
            }

            return _scope.Resolve(type);
        }
    }
}
