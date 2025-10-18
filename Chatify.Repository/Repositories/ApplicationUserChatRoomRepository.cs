using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chatify.Core.Dtos.ChatDtos;
using Chatify.Core.Entities;
using Chatify.Core.Repositories;
using Chatify.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace Chatify.Repository.Repositories
{
    public class ApplicationUserChatRoomRepository : GenericRepository<ApplicationUserChatRoom>, IApplicationUserChatRoomRepository
    {
        private readonly AppDbContext context;

        public ApplicationUserChatRoomRepository(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<UserChatRoomDto>> GetUserChatRoomsAsync(string userId)
        {
            return await context.ApplicationUserChatRooms.Where(ucr => ucr.UserId == userId)
                         .Select(ucr => new UserChatRoomDto
                         {
                             ChatRoomId = ucr.ChatRoom.Id,
                             ChatRoomName = ucr.ChatRoom.Name,
                             LastMessage = ucr.ChatRoom.Messages.OrderByDescending(m => m.SentAt)
                                                                .Select(m => m.Content).FirstOrDefault(),
                             SentAt = ucr.ChatRoom.Messages.OrderByDescending(m => m.SentAt)
                                                           .Select(m => m.SentAt).FirstOrDefault(),
                             SenderName = ucr.ChatRoom.Messages.OrderByDescending(m => m.SentAt)
                                                               .Select(m => m.Sender.DisplayName).FirstOrDefault(),
                             UnreadCount = ucr.ChatRoom.Messages
                                                .Count(m => m.MessageReads.Any(r => r.UserId == userId && !r.IsRead))
                         }).OrderBy(dto => dto.SentAt).ToListAsync();
        }
    }
}
