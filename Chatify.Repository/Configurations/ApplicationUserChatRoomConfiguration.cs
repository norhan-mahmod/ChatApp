using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chatify.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chatify.Repository.Configurations
{
    public class ApplicationUserChatRoomConfiguration : IEntityTypeConfiguration<ApplicationUserChatRoom>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserChatRoom> builder)
        {
            // Add Unique Index
            builder.HasIndex(ucr => new { ucr.UserId, ucr.ChatRoomId })
                   .IsUnique();

            // relationship to user
            builder.HasOne(ucr => ucr.User)
                   .WithMany(u => u.UserChatRooms)
                   .HasForeignKey(ucr => ucr.UserId)
                   .OnDelete(DeleteBehavior.NoAction);

            // relationship to ChatRoom
            builder.HasOne(ucr => ucr.ChatRoom)
                   .WithMany(cr => cr.ChatRoomUsers)
                   .HasForeignKey(ucr => ucr.ChatRoomId);
        }
    }
}
