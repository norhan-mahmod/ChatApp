using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatify.Core.Dtos.AuthDtos
{
    public class UserDataDto
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string ProfilePictureURL { get; set; }
    }
}
