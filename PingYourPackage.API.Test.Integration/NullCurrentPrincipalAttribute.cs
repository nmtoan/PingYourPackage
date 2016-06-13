using NUnit.Framework;
using System;
using System.Threading;

namespace PingYourPackage.API.Test.Integration
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class NullCurrentPrincipalAttribute : Attribute, ITestAction
    {
        public void AfterTest(TestDetails testDetails)
        {
            //throw new NotImplementedException();
        }

        public void BeforeTest(TestDetails testDetails)
        {
            Thread.CurrentPrincipal = null;
        }

        public ActionTargets Targets
        {
            get { return ActionTargets.Test | ActionTargets.Suite; }
        }
    }
}
