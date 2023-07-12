using CommunityToolkit.Mvvm.Messaging.Messages;

namespace SmartGenealogy.Messages;

public class OpenFileChangedMessage : ValueChangedMessage<bool>
{
    public OpenFileChangedMessage(bool fileOpen)
        : base(fileOpen)
    { }
}