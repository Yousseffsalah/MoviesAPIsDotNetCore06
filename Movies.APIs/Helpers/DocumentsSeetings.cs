namespace Movies.PL.APIs.Helpers
{
    public static class DocumentsSeetings
    {

        public async static Task<string> UploadFileTo(IFormFile file,string folderName)
        {
            
                var fileName = $"{Guid.NewGuid()}{file.FileName}";

                var filePath = Path.Combine(Directory.GetCurrentDirectory(),$"wwwroot\\{folderName}",fileName);

                FileStream fileStream = new FileStream(filePath, FileMode.CreateNew);

                await file.CopyToAsync(fileStream);

                return fileName;

        }

        public async static Task<bool> DeleteFile(string fileName, string folderName)
        {
            //get file path
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), folderName, fileName);
            //check if exists
            if(File.Exists(filePath))
            {
                File.Delete(filePath);
                return true;
            }
            return false;
        }

    }
}
