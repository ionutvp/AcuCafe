namespace AcuCafe.Interfaces
{
    public interface IInformBarista
    {
        string LastMessage { get; }
        void Inform(string message);
    }
}
