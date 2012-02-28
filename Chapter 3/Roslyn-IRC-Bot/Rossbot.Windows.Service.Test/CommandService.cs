using System.Diagnostics;
using System.ServiceModel;
using Rossbot.Api;

namespace Rossbot.Windows.Service.Test
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    class CommandService : ICommandService
    {

        public string Execute(string code)
        {
            EventLog.WriteEntry("RoslynCodeService", "Running code execution", EventLogEntryType.Information);
            var engine = new ScriptExecuter();
            var result = engine.Execute(code);

            EventLog.WriteEntry("RoslynCodeService", "Running code execution - Finished", EventLogEntryType.Information);
            return result.ToString();
        }
    }
}
