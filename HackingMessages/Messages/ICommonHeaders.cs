namespace Hacking.Messages
{
    public interface ICommonHeaders
    {
        string MessageId { get; set; }
        string MessageType { get; set; }
    }
}