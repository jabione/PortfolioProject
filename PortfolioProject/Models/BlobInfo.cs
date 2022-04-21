using System.ComponentModel.DataAnnotations;

namespace PortfolioProject.Models
{
    /// <summary>
    /// BlobInfo Model
    /// </summary>
    public class BlobInfo
    {
        public BlobInfo(Stream content, string contentType)
        {
            this.Content = content;
            this.ContentType = contentType;
        }
        public Stream Content { get; }
        public string ContentType { get; }
    }

}
