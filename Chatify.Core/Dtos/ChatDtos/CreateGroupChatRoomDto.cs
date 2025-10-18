using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Chatify.Core.Dtos.ChatDtos
{
    public class CreateGroupChatRoomDto
    {
        public string Name { get; set; }
        public IFormFile? ImageUrl { get; set; }
        public List<string> GroupMembersId  { get; set; }
    }
}
