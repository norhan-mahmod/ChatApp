using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatify.Core.Dtos
{
    public class GeneralResponseDto<T>
    {
        public bool IsSucceeded { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public List<string> Errors { get; set; }
    }
}
