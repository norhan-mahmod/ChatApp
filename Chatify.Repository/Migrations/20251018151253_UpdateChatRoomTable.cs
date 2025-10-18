using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chatify.Repository.Migrations
{
    /// <inheritdoc />
    public partial class UpdateChatRoomTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserChatRoom_AspNetUsers_UserId",
                table: "ApplicationUserChatRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserChatRoom_ChatRoom_ChatRoomId",
                table: "ApplicationUserChatRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_AspNetUsers_SenderId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_ChatRoom_ChatRoomId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageReadStatus_Message_MessageId",
                table: "MessageReadStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Message",
                table: "Message");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatRoom",
                table: "ChatRoom");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserChatRoom",
                table: "ApplicationUserChatRoom");

            migrationBuilder.RenameTable(
                name: "Message",
                newName: "Messages");

            migrationBuilder.RenameTable(
                name: "ChatRoom",
                newName: "ChatRooms");

            migrationBuilder.RenameTable(
                name: "ApplicationUserChatRoom",
                newName: "ApplicationUserChatRooms");

            migrationBuilder.RenameIndex(
                name: "IX_Message_SenderId",
                table: "Messages",
                newName: "IX_Messages_SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Message_ChatRoomId",
                table: "Messages",
                newName: "IX_Messages_ChatRoomId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserChatRoom_UserId_ChatRoomId",
                table: "ApplicationUserChatRooms",
                newName: "IX_ApplicationUserChatRooms_UserId_ChatRoomId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserChatRoom_ChatRoomId",
                table: "ApplicationUserChatRooms",
                newName: "IX_ApplicationUserChatRooms_ChatRoomId");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "ChatRooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsGroup",
                table: "ChatRooms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatRooms",
                table: "ChatRooms",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserChatRooms",
                table: "ApplicationUserChatRooms",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserChatRooms_AspNetUsers_UserId",
                table: "ApplicationUserChatRooms",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserChatRooms_ChatRooms_ChatRoomId",
                table: "ApplicationUserChatRooms",
                column: "ChatRoomId",
                principalTable: "ChatRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageReadStatus_Messages_MessageId",
                table: "MessageReadStatus",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_SenderId",
                table: "Messages",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_ChatRooms_ChatRoomId",
                table: "Messages",
                column: "ChatRoomId",
                principalTable: "ChatRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserChatRooms_AspNetUsers_UserId",
                table: "ApplicationUserChatRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserChatRooms_ChatRooms_ChatRoomId",
                table: "ApplicationUserChatRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageReadStatus_Messages_MessageId",
                table: "MessageReadStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_SenderId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_ChatRooms_ChatRoomId",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatRooms",
                table: "ChatRooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserChatRooms",
                table: "ApplicationUserChatRooms");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "ChatRooms");

            migrationBuilder.DropColumn(
                name: "IsGroup",
                table: "ChatRooms");

            migrationBuilder.RenameTable(
                name: "Messages",
                newName: "Message");

            migrationBuilder.RenameTable(
                name: "ChatRooms",
                newName: "ChatRoom");

            migrationBuilder.RenameTable(
                name: "ApplicationUserChatRooms",
                newName: "ApplicationUserChatRoom");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_SenderId",
                table: "Message",
                newName: "IX_Message_SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_ChatRoomId",
                table: "Message",
                newName: "IX_Message_ChatRoomId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserChatRooms_UserId_ChatRoomId",
                table: "ApplicationUserChatRoom",
                newName: "IX_ApplicationUserChatRoom_UserId_ChatRoomId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserChatRooms_ChatRoomId",
                table: "ApplicationUserChatRoom",
                newName: "IX_ApplicationUserChatRoom_ChatRoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Message",
                table: "Message",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatRoom",
                table: "ChatRoom",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserChatRoom",
                table: "ApplicationUserChatRoom",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserChatRoom_AspNetUsers_UserId",
                table: "ApplicationUserChatRoom",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserChatRoom_ChatRoom_ChatRoomId",
                table: "ApplicationUserChatRoom",
                column: "ChatRoomId",
                principalTable: "ChatRoom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_AspNetUsers_SenderId",
                table: "Message",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_ChatRoom_ChatRoomId",
                table: "Message",
                column: "ChatRoomId",
                principalTable: "ChatRoom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageReadStatus_Message_MessageId",
                table: "MessageReadStatus",
                column: "MessageId",
                principalTable: "Message",
                principalColumn: "Id");
        }
    }
}
