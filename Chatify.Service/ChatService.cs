using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Chatify.Core.Dtos.ChatDtos;
using Chatify.Core.Entities;
using Chatify.Core.Repositories;
using Chatify.Core.Services;
using Chatify.Core.Specifications;

namespace Chatify.Service
{
    public class ChatService : IChatService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ChatService(IUnitOfWork unitOfWork , IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<List<ChatRoomDto>> GetUserChatRooms(string userId)
        {
            var chatroomSpec = new UserChatRoomSpecification(userId);
            var chatrooms = await unitOfWork.Repository<ApplicationUserChatRoom>().GetListWithProjectionSpecificationAsync<ChatRoom>(chatroomSpec);
            var chatroomsDto = mapper.Map<List<ChatRoomDto>>(chatrooms);
            return chatroomsDto;
        }
    }
}
