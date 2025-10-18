using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Chatify.Core.Dtos;
using Chatify.Core.Dtos.ChatDtos;
using Chatify.Core.Entities;
using Chatify.Core.Repositories;
using Chatify.Core.Services;
using Chatify.Core.Specifications;
using Chatify.Service.Helper;

namespace Chatify.Service
{
    public class ChatService : IChatService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IApplicationUserChatRoomRepository applicationUserChatRoomRepository;
        private readonly IAuthService authService;

        public ChatService(IUnitOfWork unitOfWork , IMapper mapper , 
            IApplicationUserChatRoomRepository applicationUserChatRoomRepository, IAuthService authService)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.applicationUserChatRoomRepository = applicationUserChatRoomRepository;
            this.authService = authService;
        }

        // Get list of user chats to connect / disconnect him in the Hub
        public async Task<List<ChatRoomDto>> GetUserChatRooms(string userId)
        {
            var chatroomSpec = new UserChatRoomSpecification(userId);
            var chatrooms = await unitOfWork.Repository<ApplicationUserChatRoom>().GetListWithProjectionSpecificationAsync<ChatRoom>(chatroomSpec);
            var chatroomsDto = mapper.Map<List<ChatRoomDto>>(chatrooms);
            return chatroomsDto;
        }

        // Get List of User Chats with last message , sentAt , SenderName , .. for API

        public async Task<List<UserChatRoomDto>> GetUserChatRoomsWithDetailsAsync(string userId)
        {
            var chatroomsDto = await applicationUserChatRoomRepository.GetUserChatRoomsAsync(userId);
            return chatroomsDto;
        }

        // Create Group ChatRoom 
        public async Task<GeneralResponseDto<bool>> CreateGroupChatRoom(string currentUserId, CreateGroupChatRoomDto chatroomDto)
        {
            // Validate Member User Ids
            var isValidUsersId = await authService.IsValidUserIds(chatroomDto.GroupMembersId);
            if (!isValidUsersId)
                return new GeneralResponseDto<bool> { IsSucceeded = false, Message = "Invalid Member User Id!" };

            chatroomDto.GroupMembersId.Append(currentUserId);
            var chatroom = new ChatRoom()
            {
                Name = chatroomDto.Name,
                IsGroup = true,
                ChatRoomUsers = chatroomDto.GroupMembersId.Select(id => new ApplicationUserChatRoom() { UserId = id }).ToList()
            };
            // Set Group Image
            chatroom.ImageUrl = chatroomDto.ImageUrl is null ?
                "/ProfilePictures/default.jpg" 
                : await DocumentSetting.UploadFile(chatroomDto.ImageUrl, "ProfilePictures");
            await unitOfWork.Repository<ChatRoom>().Add(chatroom);
            await unitOfWork.SaveAsync();
            return new GeneralResponseDto<bool>
            {
                IsSucceeded = true,
                Message = "Group Chat Room Created Successfully!"
            };
        }

        // Create one to one user chat
        public async Task<GeneralResponseDto<ChatRoomDto>> CreateUserChat(string currentUserId, string ReceiverUserId)
        {
            // Validate Receiver User ID
            var receiverUserData = await authService.GetUserData(ReceiverUserId);
            if (!receiverUserData.IsSucceeded)
                return new GeneralResponseDto<ChatRoomDto> { IsSucceeded = false, Message = "Invalid Receiver User Id!" };

            // Create ChatRoom Contains only 2 users (one to one User ChatRoom)
            var chatroom = new ChatRoom()
            {
                Name = receiverUserData.Data?.DisplayName,
                ImageUrl = receiverUserData.Data?.ProfilePictureURL,
                IsGroup = false,
                ChatRoomUsers = new List<ApplicationUserChatRoom>()
                {
                    new ApplicationUserChatRoom() { UserId = currentUserId},
                    new ApplicationUserChatRoom() {UserId = ReceiverUserId}
                }
            };
            await unitOfWork.Repository<ChatRoom>().Add(chatroom);
            await unitOfWork.SaveAsync();
            return new GeneralResponseDto<ChatRoomDto>
            {
                IsSucceeded = true,
                Data = mapper.Map<ChatRoomDto>(chatroom)
            };
        }

    }
}
