using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatify.Core.Entities
{
    public class Message
    {
        public int Id { get; set; }

        // Sender
        public string SenderId { get; set; }
        public ApplicationUser Sender { get; set; }

        // Content
        public string Content { get; set; }
        public DateTime SentAt { get; set; }

        // Relation to chat Room
        public int ChatRoomId { get; set; }
        public ChatRoom ChatRoom { get; set; } 

        // For Images/Files
        public string AttachmentUrl { get; set; }

        // Relation to MessageReadStatus
        public List<MessageReadStatus> MessageReads { get; set; }
    }
}
