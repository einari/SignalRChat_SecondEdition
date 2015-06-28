using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SignalRChat.Mobile
{
    public partial class Chat : ContentPage
    {
        public Chat() : this("Unknown")
        {
        }

        public Chat(string room)
        {
            InitializeComponent();

            BindingContext = new ChatViewModel(room);
        }
    }
}
