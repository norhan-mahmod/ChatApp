using Chatify.Core.Repositories;
using Chatify.Core.Services;
using Chatify.Repository.Repositories;
using Chatify.Service;
using Chatify.Service.AutoMapper;

namespace Chatify.API.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IApplicationUserChatRoomRepository, ApplicationUserChatRoomRepository>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IChatService, ChatService>();
            services.AddAutoMapper(map => map.AddProfile(new MappingProfile()));
            return services;
        }
    }
}
