namespace SmartGenealogy.Messages;

public class OpenFileMessage : ValueChangedMessage<string>
{
    public OpenFileMessage(string value)
        : base(value)
    {
    }
}