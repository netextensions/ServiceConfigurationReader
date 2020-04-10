using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ServiceConfigurationReader.Test
{
    [TestClass]
    public class ServiceConfigurationReaderUnitTest
    {
        //C:\Program Files\dotnet\appsettings.json
        [TestMethod]
        public void ServiceConfigurationReaderTest()
        {
            var configuration = NetExtensions.ServiceConfigurationReader.CreateConfiguration();
        }
    }
}
