using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using ChatRoom.Extensions;

namespace ChatRoom.Api
{
    public class FileUploadController: ApiController
    {
        [HttpPost]
        public async Task<HttpResponseMessage> Upload(HttpRequestMessage request)
        {
            var imageUrl = string.Empty;
            if (!request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            var data = await Request.Content.ParseMultipartAsync();

            if (data.Files.ContainsKey("file"))
            {
                var file = data.Files["file"].File;
                var fileName = data.Files["file"].Filename;
                imageUrl = Save(file, fileName);
            }

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(imageUrl)
            };
        }

        private static string Save(byte[] file, string fileName)
        {
            const string folderName = "images";
            fileName = fileName.Replace(" ", "_");
            var domianAddress = HttpContext.Current.Request.Url;
            var path = $"{HttpRuntime.AppDomainAppPath}\\{folderName}";

            if (File.Exists(path)) Directory.CreateDirectory(path);
            
            using (var fs = new BinaryWriter(new FileStream($@"{path}\{fileName}", FileMode.Append, FileAccess.Write)))           
                fs.Write(file);

            return $"{folderName}/{fileName}";
            //{domianAddress.Scheme}://{domianAddress.Authority}/
        }
    }
}