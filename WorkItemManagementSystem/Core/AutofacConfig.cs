
using Autofac;
using System.Linq;
using System.Reflection;
using WorkItemManagementSystem.Commands.Contracts;
using WorkItemManagementSystem.Core.Contracts;

namespace WorkItemManagementSystem.Core
{
    internal sealed class AutofacConfig
    {
        public IContainer Build()
        {
            var containerBuilder = new ContainerBuilder();
            this.RegisterConvention(containerBuilder);
            this.RegisterCoreComponents(containerBuilder);
            return containerBuilder.Build();

        }

        private void RegisterConvention(ContainerBuilder builder)
        {
            var assembly = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces();

            var commandTypes = assembly.DefinedTypes.Where(typeInfo => typeInfo.ImplementedInterfaces.Contains(typeof(ICommand))).ToList();
            foreach (var commandType in commandTypes)
            {
                builder.RegisterType(commandType.AsType()).Named<ICommand>(commandType.Name.Replace("Command", ""));
            }
            // Modify this to include exceptional cases and such... (if needed)

        }

        private void RegisterCoreComponents(ContainerBuilder builder)
        {
            builder.RegisterType<DataBase>().As<IDataBase>().SingleInstance();

           // builder.RegisterType<Engine>().As<IEngine>(); // don't think it is necessary
            // Write the rest of your bindings... (if needed)
        }


    }
}
