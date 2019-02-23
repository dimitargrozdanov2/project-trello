
using Autofac;
using System;
using System.Linq;
using System.Reflection;
using WorkItemManagementSystem.Commands.Contracts;
using WorkItemManagementSystem.Core.Contracts;
using WorkItemManagementSystem.Core.Providor;

namespace WorkItemManagementSystem.Core
{
    internal sealed class AutofacConfig
    {
        public void Build()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces();

            var commandTypes = assembly.DefinedTypes.Where(typeInfo => typeInfo.ImplementedInterfaces.Contains(typeof(ICommand))).ToList();


            foreach (var commandType in commandTypes)
            {
                builder.RegisterType(commandType.AsType()).Named<ICommand>(commandType.Name.Replace("Command", "").ToLower());
            }

            builder.RegisterType<DataBase>().As<IDataBase>().SingleInstance();

            var container = builder.Build();
            var engine = container.Resolve<IEngine>();
            engine.Start();
        }
    }
}
