using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatify.Core.Dtos.ChatDtos
{
    public class UserChatRoomDto
    {
        public int ChatRoomId { get; set; }
        public string ChatRoomName { get; set; }
        public string LastMessage { get; set; }
        public DateTime SentAt { get; set; }
        public string SenderName { get; set; }
        public int UnreadCount {  get; set; }
    }
}
