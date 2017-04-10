using AcuCafe.InformBarista;
using NUnit.Framework;

namespace AcuCafe.Tests.InformBarista
{
    public class InformBaristaOnConsoleTest
    {
        private readonly InformBaristaOnConsole _informBaristaOnConsole;
        public InformBaristaOnConsoleTest()
        {
            _informBaristaOnConsole = new InformBaristaOnConsole();
        }
        [TestCase("Test message")]
        public void InformBarista_LastMessage_Is_MESSAGE(string message)
        {
            _informBaristaOnConsole.Inform(message);
            Assert.AreEqual(message, _informBaristaOnConsole.LastMessage);
        }
    }
}
