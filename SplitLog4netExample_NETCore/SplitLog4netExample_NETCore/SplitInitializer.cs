using Splitio.Services.Client.Classes;
using Splitio.Services.Client.Interfaces;
using System;

namespace SplitLog4netExample_NETCore
{
    public class SplitInitializer : ISplitInitializer
    {
        private readonly ISplitClient _splitClient;

        public SplitInitializer()
        {
            var config = new ConfigurationOptions
            {
                StreamingEnabled = false
            };

            var factory = new SplitFactory("SDK API KEY", config);
            _splitClient = factory.Client();

            try
            {
                _splitClient.BlockUntilReady(10000);
            }
            catch (Exception ex)
            {
                // log & handle 
            }
        }

        public ISplitClient GetSplitClient()
        {
            return _splitClient;
        }
    }

    public interface ISplitInitializer 
    {
        ISplitClient GetSplitClient();
    }
}
