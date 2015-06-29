using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace SignalRChat.Mobile
{
    public class ChatRoomsViewModel
    {
        string _currentRoom;
        INavigation _navigation;

        public ChatRoomsViewModel(INavigation navigation, IChatHub chatHub)
        {
            _navigation = navigation;
            Rooms = new ObservableCollection<string>();

            chatHub.RoomAdded += (room) => Device.BeginInvokeOnMainThread(() => Rooms.Add(room));
        }

        public string CurrentRoom 
        {
            get { return _currentRoom; }
            set
            {
                _currentRoom = value;
                _navigation.PushAsync(new Chat(value));
            }
        }

        public ObservableCollection<String> Rooms { get; private set; }
    }
}