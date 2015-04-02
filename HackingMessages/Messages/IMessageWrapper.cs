namespace Hacking.Messages
{
    public interface IMessageWrapper
    {
        string Headers { get; set; }
        string Payload { get; set; }
    }
}