using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chatify.Core.Entities;

namespace Chatify.Core.Specifications
{
    public class UserChatRoomSpecification : BaseSpecificationWithProjection<ApplicationUserChatRoom , ChatRoom>
    {
        public UserChatRoomSpecification(string UserId)
            :base(ucr => ucr.UserId == UserId)
        {
            AddInclude(ucr => ucr.ChatRoom);
            AddSelect(ucr => ucr.ChatRoom);
            ApplyDistinct();
        }
    }
}
