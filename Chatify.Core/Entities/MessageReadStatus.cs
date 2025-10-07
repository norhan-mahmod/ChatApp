using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chatify.Core.Enums;

namespace Chatify.Core.Entities
{
    public class MessageReadStatus
    {
        public int Id { get; set; }
        public int MessageId { get; set; }
        public Message Message { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public bool IsRead { get; set; }
        public DateTime ReadAt { get; set; }
        public MessageStatus Status { get; set; }
    }
}
