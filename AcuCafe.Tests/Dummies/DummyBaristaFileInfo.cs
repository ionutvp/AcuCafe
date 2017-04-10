using AcuCafe.InformBarista;
using FakeItEasy;

namespace AcuCafe.Tests.Dummies
{
    public class DummyBaristaFileInfo : DummyFactory<BaristaFileInfo>
    {
        protected override BaristaFileInfo Create()
        {
            return new BaristaFileInfo()
            {
                FileName = "Error.txt",
                FolderName = @"C:\AcuCafeBaristaMessages"

            };
        }
    }
}