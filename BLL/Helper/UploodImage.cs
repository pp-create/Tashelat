
using Microsoft.AspNetCore.Http;

namespace BLL.Helper
{
    public class UploodImage
    {
        public static string SaveFile(IFormFile PhotoUrl, string FolderPath)
        {

            // Get Directory
            string FilePath = Directory.GetCurrentDirectory() + "/wwwroot/" + FolderPath;

            // Get File Name
            string FileName = Guid.NewGuid() + Path.GetFileName(PhotoUrl.FileName);

            // Merge The Directory With File Name
            string FinalPath = Path.Combine(FilePath, FileName);

            // Save Your File As Stream "Data Overtime"
            using (var Stream = new FileStream(FinalPath, FileMode.Create))
            {
                PhotoUrl.CopyTo(Stream);
            }

            return FileName;
        }

        public static void RemoveFile(string FolderName, string RemovedFileName)
        {
            if (File.Exists(Directory.GetCurrentDirectory() + "/wwwroot/" + FolderName + RemovedFileName))
            {
                File.Delete(Directory.GetCurrentDirectory() + "/wwwroot/" + FolderName + RemovedFileName);
            }
            File.Delete(Directory.GetCurrentDirectory() + "/wwwroot/" + FolderName + RemovedFileName);


        }


    }
}
