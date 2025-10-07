using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chatify.Core.Entities;
using Chatify.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chatify.Repository.Configurations
{
    public class MessageReadStatusConfiguration : IEntityTypeConfiguration<MessageReadStatus>
    {
        public void Configure(EntityTypeBuilder<MessageReadStatus> builder)
        {
            // Add Unique Index
            builder.HasIndex(r => new { r.UserId, r.MessageId })
                   .IsUnique();

            // relationship to user
            builder.HasOne(r => r.User)
                   .WithMany(u => u.MessageReads)
                   .HasForeignKey(r => r.UserId)
                   .OnDelete(DeleteBehavior.NoAction);

            // relationship to Message
            builder.HasOne(r => r.Message)
                   .WithMany(m => m.MessageReads)
                   .HasForeignKey(r => r.MessageId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.Property(r => r.Status)
                   .HasDefaultValue(MessageStatus.Sent);
            builder.Property(r => r.IsRead).HasDefaultValue(false);
        }
    }
}
