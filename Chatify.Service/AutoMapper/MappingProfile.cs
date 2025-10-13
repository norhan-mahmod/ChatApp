using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Chatify.Core.Dtos.ChatDtos;
using Chatify.Core.Entities;

namespace Chatify.Service.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ChatRoom, ChatRoomDto>();
        }
    }
}
