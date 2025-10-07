using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Chatify.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public string ProfilePictureURL { get; set; }
        
        // Relationship to Message
        public List<Message> SentMessages { get; set; }

        // Relationship to ApplicationUserChatRoom
        public List<ApplicationUserChatRoom> UserChatRooms { get; set; }

        // Relationship to MessageReadStatus
        public List<MessageReadStatus> MessageReads { get; set; }
    }
}
