using Microsoft.AspNetCore.Http;

namespace Utility
{
    public static class FileUtility
    {
        public static string UploadFile(string webRootPath, string uploadPath, IFormFile file, string imagePath)
        {
            if (file == null)
            {
                return string.Empty;
            }
            if (!string.IsNullOrEmpty(imagePath))
            {
                var existingImagePath = Path.Combine(webRootPath, imagePath.TrimStart('\\'));
                if (File.Exists(existingImagePath))
                {
                    File.Delete(existingImagePath);
                }
            }
            string fileName = Guid.NewGuid().ToString();
            var uploads = Path.Combine(webRootPath, uploadPath);
            var extension = Path.GetExtension(file.FileName);
            using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
            {
                file.CopyTo(fileStreams);
            }
            return $"\\{Path.Combine(uploadPath, fileName + extension)}";
        }

        public static void DeleteFile(string webRootPath, string imagePath)
        {
            if (!string.IsNullOrEmpty(imagePath))
            {
                var existingImagePath = Path.Combine(webRootPath, imagePath.TrimStart('\\'));
                if (File.Exists(existingImagePath))
                {
                    File.Delete(existingImagePath);
                }
            }
        }
    }
}