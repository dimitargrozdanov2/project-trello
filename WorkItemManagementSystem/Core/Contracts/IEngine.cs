using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementSystem.Models;
using WorkItemManagementSystem.Models.Contracts;

namespace WorkItemManagementSystem.Core.Contracts
{
    public interface IEngine
    {
        void Start();

        IReader Reader { get; set; }

        IWriter Writer { get; set; }

        IParser Parser { get; set; }


        ///IList<Team> Teams2 { get; }

        IDictionary<string, Team> Teams { get; }

        IDictionary<string, Person> People { get; }

        //IDictionary<string, Member> MembersInTeam { get;}


    }

}
