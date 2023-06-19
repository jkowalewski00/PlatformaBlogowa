using PlatformaBlogowa.Interfaces;


namespace PlatformaBlogowa.Services
{
    public class FileUploadService : IFileUploadService
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public FileUploadService(IWebHostEnvironment environment) 
        {
            _hostingEnvironment = environment;
        }
        public async Task<string> UploadFileAsync(IFormFile file) 
        {
            var filePath = Path.Combine(_hostingEnvironment.ContentRootPath, @"wwwroot\Image", file.FileName);
            using var fileStream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(fileStream);
            return filePath;
        }
    }
}
