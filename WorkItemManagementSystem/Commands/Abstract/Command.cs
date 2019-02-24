using System;
using System.Collections.Generic;
using WorkItemManagementSystem.Commands.Contracts;
using WorkItemManagementSystem.Core.Contracts;
using WorkItemManagementSystem.Core.Providor;

namespace WorkItemManagementSystem.Commands.Abstract
{
    public abstract class Command:ICommand
    {
        private readonly IFactory factory;
        private readonly IDataBase dataBase;

        public Command(IFactory factory, IDataBase dataBase)
        {
            this.factory = factory ?? throw new ArgumentNullException("Factory can not be null"); ;
            this.dataBase = dataBase ?? throw new ArgumentNullException("Database can not be null"); ;
        }

        public IFactory Factory
        {
            get
            {
                return this.factory;
            }
        }

        public IDataBase DataBase
        {
            get
            {
                return this.dataBase;
            }
        }

        public abstract string Execute(IList<string> parameters);
 
    }
}
