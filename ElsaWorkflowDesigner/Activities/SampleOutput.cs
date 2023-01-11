using Elsa.ActivityResults;
using Elsa.Services;
using System;

namespace ElsaWorkflowDesigner.Activities
{
    public class SampleOutput : Activity
    {
        protected override IActivityExecutionResult OnExecute()
        {
            Console.WriteLine("Hello World!");

            return Done();
        }
    }
}
