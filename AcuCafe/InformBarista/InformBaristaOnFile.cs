using System;
using System.IO;
using AcuCafe.Interfaces;

namespace AcuCafe.InformBarista
{
    public class InformBaristaOnFile : IInformBarista
    {
        private readonly BaristaFileInfo _baristaFileInfo;
        

        public InformBaristaOnFile(BaristaFileInfo baristaFileInfo)
        {
            _baristaFileInfo = baristaFileInfo;
        }

        public string LastMessage { get; private set; }
        public void Inform(string message)
        {
            var filePath = Path.Combine(_baristaFileInfo.FolderName, _baristaFileInfo.FileName);
            LastMessage = message;
            try
            {
                File.AppendAllText(filePath, DateTime.UtcNow + " - " + message + Environment.NewLine);
            }
            catch (Exception ex)
            {
                throw new Exception($"Unable to write on file {filePath}." +
                                   $"Folder name ( {_baristaFileInfo.FolderName} ) and file name ( {_baristaFileInfo.FileName} )", ex);
            }
        }
    }
}