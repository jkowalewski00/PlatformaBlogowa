namespace PlatformaBlogowa.Interfaces
{
    public interface IFileUploadService
    {
        Task<String> UploadFileAsync(IFormFile file);
    }
}
