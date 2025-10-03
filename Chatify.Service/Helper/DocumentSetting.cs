using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Chatify.Service.Helper
{
    public static class DocumentSetting
    {
        public static async Task<string> UploadFile(IFormFile file , string folderName)
        {
            var fileName = $"{Guid.NewGuid()}-{Path.GetExtension(file.FileName)}";
            var filePath = Path.Combine("wwwroot", folderName, fileName);
            using(var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return $"/{folderName}/{fileName}";
        }
    }
}
