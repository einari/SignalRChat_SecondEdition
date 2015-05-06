using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace SignalRChat
{
    //[Authorize(RequireOutgoing=true)]
    public class Chat : Hub
    {
        public void Join(string room)
        {
            Groups.Add(Context.ConnectionId, room);
        }

        //[Authorize(Roles="Creator")]
        public void CreateChatRoom(string room)
        {
            if (!ChatRooms.Exists(room))
            {
                ChatRooms.Add(room);
                Clients.All.addChatRoom(room);
                Join(room);
            }
        }

        public void Send(string room, string message)
        {
            Clients.Group(room).addMessage(message);

            //Clients.All.addMessage(message);

            /*
            var room = Clients.Caller.currentChatRoom;
            Clients.Group(room).addMessage(room, message);*/
        }

        public override Task OnConnected()
        {
            foreach (var room in ChatRooms.GetAll())
                Clients.Caller.addChatRoom(room);

            Join("Lobby");

            System.Console.WriteLine("Connected");
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            System.Console.WriteLine("Disconnected");
            return base.OnDisconnected(stopCalled);
        }
    }
}
