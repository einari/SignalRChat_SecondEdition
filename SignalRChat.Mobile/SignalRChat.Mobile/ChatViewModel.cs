
namespace SignalRChat.Mobile
{
    public class ChatViewModel
    {
        public ChatViewModel(string room)
        {
            Room = room;
        }

        public string Room { get; private set; }
    }
}
