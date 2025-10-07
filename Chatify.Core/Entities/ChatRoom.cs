using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatify.Core.Entities
{
    public class ChatRoom
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // relation to ApplicationUserChatRoom
        public List<ApplicationUserChatRoom> ChatRoomUsers { get; set; }

        // relationship to Messages
        public List<Message> Messages { get; set; }
    }
}
