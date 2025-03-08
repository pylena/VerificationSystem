namespace VerificationSystem.Helper
{
    public class UploadHandler
    {
        public string Upload(IFormFile file)
        {
            //extention
            List<string> validExtenions = new List<string>() { ".pdf", ".txt" };

            string extention = Path.GetExtension(file.Name);
            if (!validExtenions.Contains(extention)) {
                return $"Extention is not vaild ({string.Join(',', validExtenions)})";

            }

            //file size
            long size = file.Length;
            if (size > (5 * 1024 * 1024))
            {
                return "Max size can be 5mb";
            }
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Docs");
            using FileStream stream = new FileStream(Path.Combine(path, file.Name), FileMode.Create);

        }
    }
}
