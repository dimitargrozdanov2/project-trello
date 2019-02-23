
namespace WorkItemManagementSystem
{

    using WorkItemManagementSystem.Core;

    class Staratup
    {
        static void Main(string[] args)
        {
            var config = new AutofacConfig();
            config.Build();

        }
    }
}
