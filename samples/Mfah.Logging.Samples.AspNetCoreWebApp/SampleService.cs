using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mfah.Logging.Samples.AspNetCoreWebApp
{
    public class SampleService
    {
        private readonly ILogger _logger;

        public SampleService(ILogger logger)
        {
            _logger = logger;
        }

        public void DoSomething()
        {
            _logger.Debug("Entering `DoSomething` method of `SampleService`");

            try
            {
                _logger.Warning("The `{0}` method is going to throw an exception.", nameof(DoSomethingElse));
                DoSomethingElse();
            }
            catch (Exception e)
            {
                _logger.Error(e);
            }

            _logger.Debug("Leaving `DoSomething` method of `SampleService`");
        }

        public void DoSomethingElse()
        {
            _logger.Critical("This needs to be implemented!");
            throw new NotImplementedException();
        }
    }
}
