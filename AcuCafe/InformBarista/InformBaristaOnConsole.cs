using System;
using AcuCafe.Interfaces;

namespace AcuCafe.InformBarista
{
    public class InformBaristaOnConsole : IInformBarista {
        public string LastMessage { get; private set; }
        public void Inform(string message)
        {
            LastMessage = message;
            Console.WriteLine(message);
        }
    }
}