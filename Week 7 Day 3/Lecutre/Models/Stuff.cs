using System.Web;

namespace Lecutre.Models
{
    public class StuffVM
    {
        public string YourName { get; set; }
        public HttpPostedFileBase UploadedFile { get; set; }

    }
}