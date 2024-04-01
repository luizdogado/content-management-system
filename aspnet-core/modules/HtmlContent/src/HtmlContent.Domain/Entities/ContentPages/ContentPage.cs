using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities;

namespace HtmlContent.Entities.ContentPages
{
    public class ContentPage : Entity<int>
    {
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }
        public string Content { get; set; }
    }
}
