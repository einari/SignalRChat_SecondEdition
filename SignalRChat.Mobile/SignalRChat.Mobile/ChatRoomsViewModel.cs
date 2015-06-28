using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace SignalRChat.Mobile
{
    public class ChatRoomsViewModel
    {
        string _selectedRoom;
        INavigation _navigation;

        public ChatRoomsViewModel(INavigation navigation)
        {
            _navigation = navigation;
            Rooms = new ObservableCollection<string>();

            Rooms.Add("Test");
            Rooms.Add("Test2");
        }

        public string SelectedRoom 
        {
            get { return _selectedRoom; }
            set
            {
                _selectedRoom = value;
                _navigation.PushAsync(new Chat(value));
            }
        }

        public ObservableCollection<String> Rooms { get; private set; }
    }
}
