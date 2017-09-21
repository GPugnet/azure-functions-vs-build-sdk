using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Hosting;
using FunctionApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task NewProjectSystem_MsTest()
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, "https://functions.azurewebsites.net?name=test")
            {
                Content = new StringContent(""),
                Properties = { { HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration() } }
            };

            var response = await HttpTriggerCSharp.Run(requestMessage , null);

            string responseString = await response.Content.ReadAsStringAsync();
            Assert.IsTrue(response.IsSuccessStatusCode);
            Assert.AreEqual("\"Hello test\"", responseString);
        }

        [TestMethod]
        public void NewProjectSystem_MsTest_Empty()
        {
            Assert.IsTrue(true);
        }
    }
}