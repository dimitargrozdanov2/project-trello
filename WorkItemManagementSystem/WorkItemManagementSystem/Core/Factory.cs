using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Core.Contracts;
using WorkItemManagementSystem.Models;
using WorkItemManagementSystem.Models.Contracts;

namespace WorkItemManagementSystem.Core
{
    class Factory:IFactory
    {
        private static IFactory instanceHolder = new Factory();

        private Factory()
        {
        }

        public static IFactory Instance
        {
            get
            {
                return instanceHolder;
            }
        }

        public IMember CreateMember(string name)
        {
            return new Member(name);
        }

    }
}
