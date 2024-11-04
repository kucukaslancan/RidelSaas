using Microsoft.AspNetCore.Http;

namespace Ridel.Application.Interfaces.Services
{
    public interface IStorageService
    {
        Task<string> UploadFileAsync(IFormFile file, string folderName);
        Task DeleteFileAsync(string fileUrl);
    }
}
