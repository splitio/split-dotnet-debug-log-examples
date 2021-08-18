using Common.Logging.Configuration;
using Splitio.Services.Client.Classes;
using System;

namespace SplitLog4netExample_NETFramework
{
    class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            InitializeLogs();
            var apikey = "API-KEY";

            var configurations = new ConfigurationOptions();

            var factory = new SplitFactory(apikey, configurations);
            var client = factory.Client();

            try
            {
                client.BlockUntilReady(10000);
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }

            Console.ReadLine();
        }


        private static void InitializeLogs()
        {
            NameValueCollection properties = new NameValueCollection
            {
                ["configType"] = "INLINE"
            };

            Common.Logging.LogManager.Adapter = new Common.Logging.Log4Net.Log4NetLoggerFactoryAdapter(properties);
        }
    }
}
