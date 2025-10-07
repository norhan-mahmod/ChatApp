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
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            // Message Sender Relationship
            builder.HasOne(m => m.Sender)
                   .WithMany(u => u.SentMessages)
                   .HasForeignKey(m => m.SenderId);

            // ChatRoom Messages Relationship
            builder.HasOne(m => m.ChatRoom)
                   .WithMany(cr => cr.Messages)
                   .HasForeignKey(m => m.ChatRoomId);
        }
    }
}
