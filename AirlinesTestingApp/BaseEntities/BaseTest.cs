using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AirlinesTestingApp.BaseEntities
{
    [TestClass]
    public class BaseTest
    {
        [TestCleanup]
        public void CleanupTest()
        {
            Driver.QuitDriver();
        }
    }
}